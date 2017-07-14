using System;
using System.Threading.Tasks;

namespace SpaceTravelMappingSystem.Service
{
    public class SpaceMapGenerator : ISpaceMapGenerator
    {
        private const int BatchSize = 10;
        private const int NrOfPlanets = 20;
        private const string FilePath = "C:\\Temp\\map.txt";
        private readonly IFileInteractionService FileInteractionService;
        private readonly IPlanetGeneratingService PlanetGeneratingService;

        public SpaceMapGenerator(IPlanetGeneratingService planetGeneratingService, IFileInteractionService fileInteractionService)
        {
            PlanetGeneratingService = planetGeneratingService;
            FileInteractionService = fileInteractionService;
        }

        public async Task GenerateMapAndWriteToFileAsync()
        {
            var nrOfBatches = NrOfPlanets/ BatchSize;

            for(int i = 0; i < nrOfBatches; i++)
            {
                await GeneratePlanetsAndInsert();
            }
        }

        private async Task GeneratePlanetsAndInsert()
        {
            var planetsBatch = PlanetGeneratingService.GeneratePlanets(BatchSize);

            await FileInteractionService.WriteToFileAsync(FilePath, planetsBatch);
        }
    }
}
