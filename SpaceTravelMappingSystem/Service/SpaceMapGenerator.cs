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

        public async Task GenerateMapAndWriteToFileAsync(string filePath)
        {
            _fileInteractionService.ClearFileContents(filePath);

            var nrOfBatches = _nrOfPlanets/_batchSize;

            for (var i = 0; i < nrOfBatches - 1; i++)
                await GeneratePlanetsAndInsert(filePath);
        }

        private async Task GeneratePlanetsAndInsert(string filePath)
        {
            var planetsBatch = _planetGeneratingService.GeneratePlanets(_batchSize);

            await _fileInteractionService.WriteToFileAsync(filePath, planetsBatch);
        }
    }
}