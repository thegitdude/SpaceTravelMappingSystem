using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceTravelMappingSystem.Model;

namespace SpaceTravelMappingSystem.Service
{
    public class PlanetGeneratingService : IPlanetGeneratingService
    {
        private const int planetSizeUpperLimit = 100000001;
        private const int planetSizeLowerLimit = 0;

        private const int planetCoordonateUpperLimit = 1000000000;
        private const int planetCoordonateLowerLimit = -1;

        public List<Planet> GeneratePlanets(int count)
        {
            var randomizer = new Random();
            var planets = new List<Planet>();
            for (int i = 0; i < count; i++)
            {
                var planet = new Planet(
                    GenerateRandomInteger(planetCoordonateLowerLimit, planetCoordonateUpperLimit, randomizer),
                    GenerateRandomInteger(planetCoordonateLowerLimit, planetCoordonateUpperLimit, randomizer),
                    GenerateRandomInteger(planetCoordonateLowerLimit, planetCoordonateUpperLimit, randomizer),
                    GenerateRandomPlanetType(randomizer),
                    GenerateRandomInteger(planetSizeLowerLimit, planetSizeUpperLimit, randomizer));

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
            return (PlanetType)GenerateRandomInteger(0, 2, randomizer);
        }
    }
}
