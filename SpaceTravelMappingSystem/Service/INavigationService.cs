using System.Collections.Generic;
using SpaceTravelMappingSystem.Model;

namespace SpaceTravelMappingSystem.Service
{
    using System.Threading.Tasks;

    public interface INavigationService
    {
        Task<List<Planet>> GetTravelDetailsAsync(string filePath);
    }
}
