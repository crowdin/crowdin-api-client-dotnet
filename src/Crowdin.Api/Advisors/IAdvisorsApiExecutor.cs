#nullable enable

using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public interface IAdvisorsApiExecutor
    {
        Task<AdvisorCheck> CreateAdvisorCheck(long projectId, CreateAdvisorCheckRequest? request = null);

        Task<AdvisorCheck> GetAdvisorCheckStatus(long projectId, string checkId);

        Task<AdvisorInsightsResponseList> ListAdvisorInsights(
            long projectId,
            AdvisorInsightsListParams? @params = null);

        Task<AdvisorInsight> EditAdvisorInsight(
            long projectId,
            long insightId,
            IEnumerable<EditAdvisorInsightPatch> patches);

        Task CreateOrUpdateApplicationAdvisorInsight(
            long projectId,
            string applicationIdentifier,
            string moduleKey,
            CreateOrUpdateApplicationAdvisorInsightRequest request);
    }
}
