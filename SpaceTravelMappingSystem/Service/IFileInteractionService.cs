using SpaceTravelMappingSystem.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceTravelMappingSystem.Service
{
    public interface IFileInteractionService
    {
        Task WriteToFileAsync(string filePath, object data);

        Task<SortedDictionary<double, List<Planet>>> ReadFromFileAsync(string filePath);
    }
}
