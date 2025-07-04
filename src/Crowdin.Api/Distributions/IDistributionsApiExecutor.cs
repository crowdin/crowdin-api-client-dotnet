
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace Crowdin.Api.Distributions
{
    [PublicAPI]
    public interface IDistributionsApiExecutor
    {
        Task<ResponseList<Distribution>> ListDistributions(long projectId, int limit = 25, int offset = 0);

        Task<Distribution> AddDistribution(long projectId, AddDistributionRequest request);

        Task<Distribution> AddDistributionStringBased(long projectId, AddDistributionStringBasedRequest request);

        Task<Distribution> GetDistribution(long projectId, string hash);

        Task DeleteDistribution(long projectId, string hash);

        Task<Distribution> EditDistribution(long projectId, string hash, IEnumerable<DistributionPatch> patches);

        Task<DistributionRelease> GetDistributionRelease(long projectId, string hash);

        Task<DistributionStringBasedRelease> GetDistributionReleaseStringBased(long projectId, string hash);

        Task<DistributionRelease> ReleaseDistribution(long projectId, string hash);

        Task<DistributionStringBasedRelease> StringBasedReleaseDistribution(long projectId, string hash);
    }
}