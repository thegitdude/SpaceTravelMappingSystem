using System.Collections.Generic;
using SpaceTravelMappingSystem.Model;

namespace SpaceTravelMappingSystem.Service
{
    public interface IPlanetGeneratingService
    {
        List<Planet> GeneratePlanets(int count);
    }
}
