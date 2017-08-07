using System.Threading.Tasks;

namespace SpaceTravelMappingSystem.Service
{
    public interface ISpaceMapGenerator
    {
        Task GenerateMapAndWriteToFileAsync(string filePath);
    }
}
