using System.Collections.Generic;
using SpaceTravelMappingSystem.Model;

namespace SpaceTravelMappingSystem.Service
{
    using System.Threading.Tasks;
    using Repository;
    using Utility;

    public class NavigationService : INavigationService
    {
        private readonly int _travelTimeInMinutes;
        private readonly int _expeditionTimeInHours;
        private readonly int _numberOfPlanetsToBeColonized;
        private readonly IFileInteractionRepository _fileService;

        public NavigationService(IFileInteractionRepository fileService)
        {
            _fileService = fileService;
            _expeditionTimeInHours = ConfigurationReader.ReadInt("expeditionTimeInHours");
            _numberOfPlanetsToBeColonized = ConfigurationReader.ReadInt("nrOfPlanetsToBeColonized");
            _travelTimeInMinutes = ConfigurationReader.ReadInt("travelTimeInMinutes");
        }

        public async Task<List<Planet>> GetTravelDetailsAsync(string filePath)
        {
            var expeditionTimeInMinutes = _expeditionTimeInHours*60;
            var totalTravelTime = _numberOfPlanetsToBeColonized * _travelTimeInMinutes;

            var availableColonizationTime = expeditionTimeInMinutes - totalTravelTime;

            var sortedDictionary = await _fileService.ReadFromFileAsync(filePath);  

            var planetList = new List<Planet>();

            return planetList;
        }
    }
}
