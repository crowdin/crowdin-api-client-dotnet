
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace Crowdin.Api.Distributions
{
    [PublicAPI]
    public interface IDistributionsApiExecutor
    {
        Task<ResponseList<Distribution>> ListDistributions(int projectId, int limit = 25, int offset = 0);

        Task<Distribution> AddDistribution(int projectId, AddDistributionRequest request);

        Task<Distribution> AddDistributionStringBased(int projectId, AddDistributionStringBasedRequest request);

        Task<Distribution> GetDistribution(int projectId, string hash);

        Task DeleteDistribution(int projectId, string hash);

        Task<Distribution> EditDistribution(int projectId, string hash, IEnumerable<DistributionPatch> patches);

        Task<DistributionRelease> GetDistributionRelease(int projectId, string hash);

        Task<DistributionStringBasedRelease> GetDistributionReleaseStringBased(int projectId, string hash);

        Task<DistributionRelease> ReleaseDistribution(int projectId, string hash);

        Task<DistributionStringBasedRelease> StringBasedReleaseDistribution(int projectId, string hash);
    }
}