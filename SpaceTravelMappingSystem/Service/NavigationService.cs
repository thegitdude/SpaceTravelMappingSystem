using System.Collections.Generic;
using SpaceTravelMappingSystem.Model;
using System.Threading.Tasks;

namespace SpaceTravelMappingSystem.Service
{
    public class NavigationService : INavigationService
    {
        private readonly IFileInteractionService _fileService;

        public NavigationService(IFileInteractionService fileService)
        {
            _fileService = fileService;
        }

        public async Task<List<Planet>> GetTravelDetailsAsync(string filePath)
        {
            var p = await _fileService.ReadFromFileAsync(filePath);

            
        }
    }
}
