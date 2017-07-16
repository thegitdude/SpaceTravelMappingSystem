using SpaceTravelMappingSystem.Model;
using System;

namespace SpaceTravelMappingSystem.Service
{
    public class DistanceCalculationService : IDistanceCalculationService
    {
        private readonly int homeX;
        private readonly int homeY;
        private readonly int homeZ;

        public DistanceCalculationService()
        {
            homeX = 1;
            homeY = 2;
            homeZ = 3;
        }

        public double GetDistanceToHomePlanet(Planet p)
        {
            var xDiff = homeX - p.X;
            var yDiff = homeY - p.Y;
            var zDiff = homeZ - p.Z;

            return Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2) + Math.Pow(zDiff, 3));
        }
    }
}
