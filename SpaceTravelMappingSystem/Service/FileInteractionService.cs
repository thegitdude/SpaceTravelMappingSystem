using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpaceTravelMappingSystem.Service
{
    public class FileInteractionService : IFileInteractionService
    {
        private const int BufferSize = 4096;

        public async Task<T> ReadFromFileAsync<T>(string filePath)
        {
            using (FileStream sourceStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read,
                    bufferSize: BufferSize, useAsync: true))
            {
                StringBuilder sb = new StringBuilder();

                byte[] buffer = new byte[0x1000];
                int numRead;
                while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string text = Encoding.Unicode.GetString(buffer, 0, numRead);
                    sb.Append(text);
                }

                var result = sb.ToString();
                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        public async Task WriteToFileAsync(string filePath, object data)
        {
            var dataInJson = JsonConvert.SerializeObject(data);
            byte[] encodedText = Encoding.Unicode.GetBytes(dataInJson);

            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Append, FileAccess.Write, FileShare.None,
                bufferSize: BufferSize, useAsync: true))
            {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            };
        }
    }
}
