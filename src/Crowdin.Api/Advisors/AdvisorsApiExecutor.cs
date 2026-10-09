#nullable enable

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Advisors
{
    public class AdvisorsApiExecutor : IAdvisorsApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public AdvisorsApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public AdvisorsApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        /// <summary>
        /// Create an Advisor check. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#operation/api.projects.advisors.checks.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#operation/api.projects.advisors.checks.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AdvisorCheck> CreateAdvisorCheck(long projectId, CreateAdvisorCheckRequest? request = null)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest($"/projects/{projectId}/advisors/checks", request);
            return _jsonParser.ParseResponseObject<AdvisorCheck>(result.JsonObject);
        }

        /// <summary>
        /// Get Advisor check status. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#operation/api.projects.advisors.checks.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#operation/api.projects.advisors.checks.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AdvisorCheck> GetAdvisorCheckStatus(long projectId, string checkId)
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest($"/projects/{projectId}/advisors/checks/{checkId}");
            return _jsonParser.ParseResponseObject<AdvisorCheck>(result.JsonObject);
        }

        /// <summary>
        /// List Advisor insights. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#operation/api.projects.advisors.insights.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#operation/api.projects.advisors.insights.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AdvisorInsightsResponseList> ListAdvisorInsights(long projectId, AdvisorInsightsListParams? @params = null)
        {
            IDictionary<string, string> queryParams = @params?.ToQueryParams() ?? Utils.CreateQueryParamsFromPaging(25, 0);
            CrowdinApiResult result = await _apiClient.SendGetRequest($"/projects/{projectId}/advisors/insights", queryParams);
            return new AdvisorInsightsResponseList
            {
                Data = new List<AdvisorInsight>(_jsonParser.ParseArray<AdvisorInsight>(result.JsonObject["data"]!)),
                Pagination = result.JsonObject["pagination"]?.ToObject<AdvisorInsightsPagination>()
            };
        }

        /// <summary>
        /// Edit an Advisor insight. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#operation/api.projects.advisors.insights.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#operation/api.projects.advisors.insights.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AdvisorInsight> EditAdvisorInsight(long projectId, long insightId, IEnumerable<EditAdvisorInsightPatch> patches)
        {
            CrowdinApiResult result = await _apiClient.SendPatchRequest($"/projects/{projectId}/advisors/insights/{insightId}", patches);
            return _jsonParser.ParseResponseObject<AdvisorInsight>(result.JsonObject);
        }

        /// <summary>
        /// Create or update an application Advisor insight. Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#operation/api.projects.applications.modules.advisors.insights.put">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task CreateOrUpdateApplicationAdvisorInsight(
            long projectId,
            string applicationIdentifier,
            string moduleKey,
            CreateOrUpdateApplicationAdvisorInsightRequest request)
        {
            await _apiClient.SendPutRequest(
                $"/projects/{projectId}/applications/{applicationIdentifier}/modules/{moduleKey}/advisors/insights", request);
        }
    }
}
