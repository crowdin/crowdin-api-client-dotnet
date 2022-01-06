
using System.Collections.Generic;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.Issues
{
    public class IssuesApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public IssuesApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }
        
        public IssuesApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        [PublicAPI]
        public Task<ResponseList<Issue>> ListReportedIssues(
            int projectId, int limit = 25, int offset = 0,
            IssueType? type = null, IssueStatus? status = null)
        {
            return ListReportedIssues(projectId, new IssuesListParams(limit, offset, type, status));
        }

        [PublicAPI]
        public async Task<ResponseList<Issue>> ListReportedIssues(int projectId, IssuesListParams @params)
        {
            var url = $"/projects/{projectId}/issues";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<Issue>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<Issue> EditIssue(int projectId, int issueId, IEnumerable<IssuePatch> patches)
        {
            var url = $"/projects/{projectId}/issues/{issueId}";
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Issue>(result.JsonObject);
        }
    }
}