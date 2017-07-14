using System.Threading.Tasks;

namespace SpaceTravelMappingSystem.Service
{
    public interface IFileInteractionService
    {
        Task WriteToFileAsync(string filePath, object data);

        Task<T> ReadFromFileAsync<T>(string filePath);
    }
}
