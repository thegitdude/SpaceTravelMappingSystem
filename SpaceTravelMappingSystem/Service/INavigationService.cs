using System;
using System.Collections.Generic;
using SpaceTravelMappingSystem.Model;

namespace SpaceTravelMappingSystem.Service
{
    public interface INavigationService
    {
        List<Planet> GetTravelDetails(SortedDictionary<int, Planet> planetDictionary);
    }
}
