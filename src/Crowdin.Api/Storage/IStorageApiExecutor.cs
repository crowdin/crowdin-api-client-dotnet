
using System.IO;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace Crowdin.Api.Storage
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