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

        public double GetDistanceToHomePlanet(int x, int y, int z)
        {
            var xDiff = homeX - x;
            var yDiff = homeY - y;
            var zDiff = homeZ - z;

            return Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2) + Math.Pow(zDiff, 3));
        }
    }
}
