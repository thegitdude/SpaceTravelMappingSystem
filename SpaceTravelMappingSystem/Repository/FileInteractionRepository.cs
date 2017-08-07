namespace SpaceTravelMappingSystem.Repository
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using Model;
    using Newtonsoft.Json;
    using Service;

    public class FileInteractionRepository : IFileInteractionRepository
    {
        private const int BufferSize = 4096;
        private readonly IDistanceCalculationService _distanceCalculationService;

        public FileInteractionRepository(IDistanceCalculationService distanceCalculationService)
        {
            _distanceCalculationService = distanceCalculationService;
        }

        //Reading one line at a time saves memory.
        //Further improvements could be made by reducing the size of the sorted dictionary to hold 10 planets only and sorting on the fly.
        public async Task<SortedDictionary<double, List<Planet>>> ReadFromFileAsync(string filePath)
        {
            using (FileStream sourceStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read,
                    bufferSize: BufferSize, useAsync: true))
            {
                var file = new StreamReader(sourceStream, Encoding.Unicode, true, 128);

                var planetDictionary = new SortedDictionary<double, List<Planet>>();
                string lineOfText;
                while ((lineOfText = await file.ReadLineAsync()) != null)
                {
                    if (lineOfText.Length > 0)
                    {
                        var planets = JsonConvert.DeserializeObject<List<Planet>>(lineOfText);
                        AddToDictionary(planetDictionary, planets);
                    }
                }

                return planetDictionary;
            }
        }

        public async Task WriteToFileAsync(string filePath, object data)
        {
            var dataInJson = JsonConvert.SerializeObject(data) + Environment.NewLine;
            byte[] encodedText = Encoding.Unicode.GetBytes(dataInJson);

            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Append, FileAccess.Write, FileShare.None,
                bufferSize: BufferSize, useAsync: true))
            {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
                sourceStream.Close();
            };
        }

        public void ClearFileContents(string filePath)
        {
            File.WriteAllText(filePath, String.Empty);
        }

        //I am discarding all planets except the inhabitable ones. in 24h the max colonized space would be 250000 square km which is less than half of the smallest planet.
        // I considered that both inhabitable and uninhabitable planets would have the same size requirements even thought the text points this out for inhabitable ones. 
        // An uninhabitable planet less than 250000 square km could be made inhabitable but that would make it 2000 times smaller than earth so it wouldn't be worth it.

        private void AddToDictionary(SortedDictionary<double, List<Planet>> d, List<Planet> planets)
        {
            foreach (var planet in planets)
            {
                if (planet.Type == PlanetType.Inhabitable)
                {
                    var distanceToHomePlanet = _distanceCalculationService.GetDistanceToHomePlanet(planet);

                    List<Planet> bucket;
                    var keyExists = d.TryGetValue(distanceToHomePlanet, out bucket);
                    if (keyExists)
                    {
                        bucket.Add(planet);
                    }
                    else
                    {
                        bucket = new List<Planet>();
                        bucket.Add(planet);
                        d.Add(distanceToHomePlanet, bucket);
                    }
                }
            }
        }
    }
}
