namespace SpaceTravelMappingSystem.Service
{
    using System.Threading.Tasks;
    using Model;

    public interface INavigationService
    {
        Task<NavigationProcessingResult> GetTravelDetailsAsync(string filePath);
    }
}