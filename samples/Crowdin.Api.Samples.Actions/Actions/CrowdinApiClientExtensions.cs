
using Crowdin.Api.Storage;

namespace Crowdin.Api.Samples.Actions
{
    public static class CrowdinApiClientExtensions
    {
        public static async Task<StorageResource> AddStorage(this ICrowdinApiClient apiClient, string filepath)
        {
            string fileName = Path.GetFileName(filepath);
            
            await using FileStream fileStream = File.OpenRead(filepath);
            
            return await apiClient.Storage.AddStorage(fileStream, fileName);
        }
    }
}