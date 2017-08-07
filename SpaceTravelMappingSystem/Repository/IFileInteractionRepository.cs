using SpaceTravelMappingSystem.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceTravelMappingSystem.Repository
{
    public interface IFileInteractionRepository
    {
        Task WriteToFileAsync(string filePath, object data);

        Task<SortedDictionary<double, List<Planet>>> ReadFromFileAsync(string filePath);

        void ClearFileContents(string filePath);
    }
}
