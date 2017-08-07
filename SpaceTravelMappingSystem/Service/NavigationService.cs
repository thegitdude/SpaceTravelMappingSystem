namespace SpaceTravelMappingSystem.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Model;
    using Repository;
    using Utility;

    public class NavigationService : INavigationService
    {
        private readonly int _expeditionTimeInHours;
        private readonly IFileInteractionRepository _fileService;
        private readonly int _numberOfPlanetsToBeColonized;
        private readonly int _travelTimeInMinutes;
        private readonly decimal _colonizationSpeedSqKmPerSecond;

        public NavigationService(IFileInteractionRepository fileService)
        {
            _fileService = fileService;
            _colonizationSpeedSqKmPerSecond = ConfigurationReader.ReadDecimal("colonizationSpeedSqKmPerSecond");
            _expeditionTimeInHours = ConfigurationReader.ReadInt("expeditionLengthInHours");
            _numberOfPlanetsToBeColonized = ConfigurationReader.ReadInt("nrOfPlanetsToBeColonized");
            _travelTimeInMinutes = ConfigurationReader.ReadInt("travelTimeInMinutes");
        }

        public async Task<NavigationProcessingResult> GetTravelDetailsAsync(string filePath)
        {
            var expeditionTimeInMinutes = _expeditionTimeInHours * 60;
            var totalTravelTime = _numberOfPlanetsToBeColonized *_travelTimeInMinutes;

            var availableColonizationTimeInSeconds = (expeditionTimeInMinutes - totalTravelTime) * 60;
            var maximumColonizationPotential = availableColonizationTimeInSeconds * _colonizationSpeedSqKmPerSecond;

            var sortedDictionary = await _fileService.ReadFromFileAsync(filePath);

            var planetList = new List<Planet>();
            var i = 0;
            while (true)
            {
                var remainingSpaces = _numberOfPlanetsToBeColonized - planetList.Count;
                var planetBucket = sortedDictionary.ElementAt(i).Value;

                if (remainingSpaces > planetBucket.Count)
                {
                    planetList.AddRange(planetBucket);
                }
                else
                {
                    planetList.AddRange(planetBucket.Take(remainingSpaces));
                    break;
                }
                i++;
            }

            return new NavigationProcessingResult(planetList, maximumColonizationPotential);
        }
    }
}