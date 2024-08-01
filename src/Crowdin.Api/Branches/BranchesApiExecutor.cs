
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.Branches
{
    public class BranchesApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;
        
        public BranchesApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }
        
        public BranchesApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }
        
        /// <summary>
        /// Get Cloned Branch. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.projects.branches.clones.branch.get">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/string-based/#operation/api.projects.branches.clones.branch.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Branch> GetClonedBranch(int projectId, int branchId, string cloneId)
        {
            var url = $"/projects/{projectId}/branches/{branchId}/clones/{cloneId}/branch";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Branch>(result.JsonObject);
        }
        
        /// <summary>
        /// Clone Branch. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.projects.branches.clones.post">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/string-based/#operation/api.projects.branches.clones.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<BranchCloneStatus> CloneBranch(int projectId, int branchId, CloneBranchRequest request)
        {
            var url = $"/projects/{projectId}/branches/{branchId}/clones";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<BranchCloneStatus>(result.JsonObject);
        }
        
        /// <summary>
        /// Check Branch Clone Status. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.projects.branches.clones.get">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/string-based/#operation/api.projects.branches.clones.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<BranchCloneStatus> CheckBranchCloneStatus(int projectId, int branchId, string cloneId)
        {
            var url = $"/projects/{projectId}/branches/{branchId}/clones/{cloneId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<BranchCloneStatus>(result.JsonObject);
        }
        
        /// <summary>
        /// List Branches. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.projects.branches.getMany">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/string-based/#operation/api.projects.branches.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<Branch>> ListBranches(
            int projectId,
            string? name = null,
            IEnumerable<SortingRule>? orderBy = null,
            int limit = 25,
            int offset = 0)
        {
            string url = FormUrl_Branches(projectId);
            
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.AddParamIfPresent("name", name);
            queryParams.AddSortingRulesIfPresent(orderBy);
            
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<Branch>(result.JsonObject);
        }
        
        /// <summary>
        /// Add Branch. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.projects.branches.post">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/string-based/#operation/api.projects.branches.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Branch> AddBranch(int projectId, AddBranchRequest request)
        {
            string url = FormUrl_Branches(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<Branch>(result.JsonObject);
        }
        
        /// <summary>
        /// Get Branch. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.projects.branches.get">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/string-based/#operation/api.projects.branches.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Branch> GetBranch(int projectId, int branchId)
        {
            string url = FormUrl_BranchId(projectId, branchId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Branch>(result.JsonObject);
        }
        
        /// <summary>
        /// Delete Branch. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.projects.branches.delete">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/string-based/#operation/api.projects.branches.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteBranch(int projectId, int branchId)
        {
            string url = FormUrl_BranchId(projectId, branchId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Branch {branchId} removal failed");
        }
        
        /// <summary>
        /// Edit Branch. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.projects.branches.patch">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/string-based/#operation/api.projects.branches.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Branch> EditBranch(int projectId, int branchId, IEnumerable<BranchPatch> patches)
        {
            string url = FormUrl_BranchId(projectId, branchId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Branch>(result.JsonObject);
        }
        
        /// <summary>
        /// Merge Branch. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.projects.branches.merges.post">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/string-based/#operation/api.projects.branches.merges.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<BranchMergeStatus> MergeBranch(int projectId, int branchId, MergeBranchRequest request)
        {
            var url = $"/projects/{projectId}/branches/{branchId}/merges";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<BranchMergeStatus>(result.JsonObject);
        }
        
        /// <summary>
        /// Check Branch Merge Status. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.projects.branches.merges.get">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/string-based/#operation/api.projects.branches.merges.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<BranchMergeStatus> CheckBranchMergeStatus(int projectId, int branchId, string mergeId)
        {
            var url = $"/projects/{projectId}/branches/{branchId}/merges/{mergeId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<BranchMergeStatus>(result.JsonObject);
        }
        
        /// <summary>
        /// Get Branch Merge Summary. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.projects.branches.merges.summary.get">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/string-based/#operation/api.projects.branches.merges.summary.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<BranchMergeSummary> GetBranchMergeSummary(int projectId, int branchId, string mergeId)
        {
            var url = $"/projects/{projectId}/branches/{branchId}/merges/{mergeId}/summary";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<BranchMergeSummary>(result.JsonObject);
        }
        
        #region Helper methods
        
        private static string FormUrl_Branches(int projectId)
        {
            return $"/projects/{projectId}/branches";
        }
        
        private static string FormUrl_BranchId(int projectId, int branchId)
        {
            return $"/projects/{projectId}/branches/{branchId}";
        }
        
        #endregion
    }
}