
using System.IO;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Storage;

namespace Crowdin.Api.Abstractions
{
    [PublicAPI]
    public interface IStorageApiExecutor
    {
        Task<ResponseList<StorageResource>> ListStorages(int limit = 25, int offset = 0);

        Task<StorageResource> AddStorage(Stream fileStream, string filename);

        Task<StorageResource> GetStorage(long storageId);

        Task DeleteStorage(long storageId);
    }
}