
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.SourceFiles;

namespace Crowdin.Api.Bundles
{
    [PublicAPI]
    public interface IBundlesApiExecutor
    {
        Task<ResponseList<Bundle>> ListBundles(long projectId, int limit = 25, int offset = 0);

        Task<ResponseList<Branch>> ListBundleBranches(long projectId, long bundleId, int limit = 25, int offset = 0);

        Task<Bundle> AddBundle(long projectId, AddBundleRequest request);

        Task<Bundle> GetBundle(long projectId, long bundleId);

        Task DeleteBundle(long projectId, long bundleId);

        Task<Bundle> EditBundle(long projectId, long bundleId, IEnumerable<BundlePatch> patches);

        Task<DownloadLink> DownloadBundle(long projectId, long bundleId, string exportId);

        Task<BundleExport> ExportBundle(long projectId, long bundleId);

        Task<BundleExport> CheckBundleExportStatus(long projectId, long bundleId, string exportId);

        Task<ResponseList<T>> BundleListFiles<T>(long projectId, long bundleId, int limit = 25, int offset = 0) where T : FileResourceBase;
    }
}