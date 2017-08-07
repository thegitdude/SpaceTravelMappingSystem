using SpaceTravelMappingSystem.Model;
using System;

namespace SpaceTravelMappingSystem.Service
{
    public class DistanceCalculationService : IDistanceCalculationService
    {
        private readonly int _homeX;
        private readonly int _homeY;
        private readonly int _homeZ;

        public DistanceCalculationService()
        {
            _homeX = 1;
            _homeY = 2;
            _homeZ = 3;
        }

        public double GetDistanceToHomePlanet(Planet p)
        {
            var xDiff = _homeX - p.X;
            var yDiff = _homeY - p.Y;
            var zDiff = _homeZ - p.Z;

            return Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2) + Math.Pow(zDiff, 3));
        }
    }
}
