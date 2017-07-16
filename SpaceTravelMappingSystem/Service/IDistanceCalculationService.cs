using SpaceTravelMappingSystem.Model;

namespace SpaceTravelMappingSystem.Service
{
    public interface IDistanceCalculationService
    {
        double GetDistanceToHomePlanet(Planet p);
    }
}
