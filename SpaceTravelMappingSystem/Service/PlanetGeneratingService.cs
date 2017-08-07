using System;
using System.Collections.Generic;
using SpaceTravelMappingSystem.Model;

namespace SpaceTravelMappingSystem.Service
{
    public class PlanetGeneratingService : IPlanetGeneratingService
    {
        private const int PlanetSizeUpperLimit = 100000001;
        private const int PlanetSizeLowerLimit = 1;

        private const int PlanetCoordonateUpperLimit = 1000000000;
        private const int PlanetCoordonateLowerLimit = 0;

        public List<Planet> GeneratePlanets(int count)
        {
            var randomizer = new Random();
            var planets = new List<Planet>();
            for (int i = 0; i < count; i++)
            {
                var planet = new Planet(
                    GenerateRandomInteger(PlanetCoordonateLowerLimit, PlanetCoordonateUpperLimit, randomizer),
                    GenerateRandomInteger(PlanetCoordonateLowerLimit, PlanetCoordonateUpperLimit, randomizer),
                    GenerateRandomInteger(PlanetCoordonateLowerLimit, PlanetCoordonateUpperLimit, randomizer),
                    GenerateRandomPlanetType(randomizer),
                    GenerateRandomInteger(PlanetSizeLowerLimit, PlanetSizeUpperLimit, randomizer));

                planets.Add(planet);
            }

            return planets;
        }

        private int GenerateRandomInteger(int lowerLimit, int upperLimit, Random randomizer)
        {
            return randomizer.Next(lowerLimit, upperLimit);
        }

        private PlanetType GenerateRandomPlanetType(Random randomizer)
        {
            return (PlanetType)GenerateRandomInteger(0, 3, randomizer);
        }
    }
}
