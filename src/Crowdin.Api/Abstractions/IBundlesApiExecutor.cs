
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Bundles;
using Crowdin.Api.SourceFiles;

namespace Crowdin.Api.Abstractions
{
    [PublicAPI]
    public interface IBundlesApiExecutor
    {
        Task<ResponseList<Bundle>> ListBundles(int projectId, int limit = 25, int offset = 0);

        Task<ResponseList<Branch>> ListBundleBranches(int projectId, int bundleId, int limit = 25, int offset = 0);

        Task<Bundle> AddBundle(int projectId, AddBundleRequest request);

        Task<Bundle> GetBundle(int projectId, int bundleId);

        Task DeleteBundle(int projectId, int bundleId);

        Task<Bundle> EditBundle(int projectId, int bundleId, IEnumerable<BundlePatch> patches);

        Task<DownloadLink> DownloadBundle(int projectId, int bundleId, string exportId);

        Task<BundleExport> ExportBundle(int projectId, int bundleId);

        Task<BundleExport> CheckBundleExportStatus(int projectId, int bundleId, string exportId);

        Task<ResponseList<T>> BundleListFiles<T>(int projectId, int bundleId, int limit = 25, int offset = 0) where T : FileResourceBase;
    }
}