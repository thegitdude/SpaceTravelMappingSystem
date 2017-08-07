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
                    Console.WriteLine(lineOfText);
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
            Console.WriteLine("Writing: " + dataInJson);
            byte[] encodedText = Encoding.Unicode.GetBytes(dataInJson);

            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Append, FileAccess.Write, FileShare.None,
                bufferSize: BufferSize, useAsync: true))
            {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            };
        }

        public void ClearFileContents(string filePath)
        {
            File.WriteAllText(filePath, String.Empty);
        }

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
