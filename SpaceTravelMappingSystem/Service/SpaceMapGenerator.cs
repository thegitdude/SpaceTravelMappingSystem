namespace SpaceTravelMappingSystem.Service
{
    using System.Threading.Tasks;
    using Repository;
    using Utility;

    public class SpaceMapGenerator : ISpaceMapGenerator
    {
        private readonly IFileInteractionRepository _fileInteractionService;
        private readonly IPlanetGeneratingService _planetGeneratingService;
        private readonly int _batchSize;
        private readonly int _nrOfPlanets;

        public SpaceMapGenerator(IPlanetGeneratingService planetGeneratingService, IFileInteractionRepository fileInteractionService)
        {
            _planetGeneratingService = planetGeneratingService;
            _fileInteractionService = fileInteractionService;
            _batchSize = ConfigurationReader.ReadInt("batchSize");
            _nrOfPlanets = ConfigurationReader.ReadInt("nrOfPlanets");
        }

        //I decided to use batching so I don't over use memory. Like this I only load 1000 objects at a time in memory.
        public async Task GenerateMapAndWriteToFileAsync(string filePath)
        {
            _fileInteractionService.ClearFileContents(filePath);

            var nrOfBatches = _nrOfPlanets/_batchSize;

            for (var i = 0; i < nrOfBatches - 1; i++)
                await GeneratePlanetsAndInsertAsync(filePath);
        }

        private async Task GeneratePlanetsAndInsertAsync(string filePath)
        {
            var planetsBatch = _planetGeneratingService.GeneratePlanets(_batchSize);

            await _fileInteractionService.WriteToFileAsync(filePath, planetsBatch);
        }
    }
}