namespace SpaceTravelMappingSystem.Service
{
    using System;
    using Model;
    using Utility;

    public class DistanceCalculationService : IDistanceCalculationService
    {
        private readonly int _homeX;
        private readonly int _homeY;
        private readonly int _homeZ;

        public DistanceCalculationService()
        {
            _homeX = ConfigurationReader.ReadInt("homePlanetX");
            _homeY = ConfigurationReader.ReadInt("homePlanetY");
            _homeZ = ConfigurationReader.ReadInt("homePlanetZ");
        }

        //This is the geometrical formula for the distance between 3  point is a 3D space given 3 values on the x, y, z axys 
        public double GetDistanceToHomePlanet(Planet p)
        {
            double xDiff = Math.Abs(_homeX - p.X);
            double yDiff = Math.Abs(_homeY - p.Y);
            double zDiff = Math.Abs(_homeZ - p.Z);

            var result = Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2) + Math.Pow(zDiff, 3));

            return result;
        }
    }
}