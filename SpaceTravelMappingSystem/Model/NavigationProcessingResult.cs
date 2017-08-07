namespace SpaceTravelMappingSystem.Model
{
    using System.Collections.Generic;

    public class NavigationProcessingResult
    {
        public NavigationProcessingResult(
            List<Planet> closestPlanets,
            decimal maxColonizableSpace)
        {
            ClosestPlanets = closestPlanets;
            MaxColonizableSpace = maxColonizableSpace;
        }

        public List<Planet> ClosestPlanets { get; }

        public decimal MaxColonizableSpace { get; }
    }
}