
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.Distributions
{
    public class DistributionsApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public DistributionsApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public DistributionsApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        /// <summary>
        /// List distributions. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.distributions.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.distributions.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<Distribution>> ListDistributions(int projectId, int limit = 25, int offset = 0)
        {
            string url = FormUrl_Distributions(projectId);
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);

            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<Distribution>(result.JsonObject);
        }

        /// <summary>
        /// Add distribution. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.distributions.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.distributions.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Distribution> AddDistribution(int projectId, AddDistributionRequest request)
        {
            string url = FormUrl_Distributions(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<Distribution>(result.JsonObject);
        }

        /// <summary>
        /// Get distribution. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.distributions.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.distributions.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Distribution> GetDistribution(int projectId, string hash)
        {
            string url = FormUrl_Distribution(projectId, hash);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Distribution>(result.JsonObject);
        }

        /// <summary>
        /// Delete distribution. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.distributions.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.distributions.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteDistribution(int projectId, string hash)
        {
            string url = FormUrl_Distribution(projectId, hash);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Distribution {hash} removal failed");
        }

        /// <summary>
        /// Edit distribution. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.distributions.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.distributions.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Distribution> EditDistribution(int projectId, string hash, IEnumerable<DistributionPatch> patches)
        {
            string url = FormUrl_Distribution(projectId, hash);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Distribution>(result.JsonObject);
        }

        /// <summary>
        /// Get distribution release. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.distributions.release.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.distributions.release.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<DistributionRelease> GetDistributionRelease(int projectId, string hash)
        {
            string url = FormUrl_DistributionRelease(projectId, hash);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<DistributionRelease>(result.JsonObject);
        }

        /// <summary>
        /// Release distribution. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.distributions.release.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.distributions.release.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<DistributionRelease> ReleaseDistribution(int projectId, string hash)
        {
            string url = FormUrl_DistributionRelease(projectId, hash);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url);
            return _jsonParser.ParseResponseObject<DistributionRelease>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_Distributions(int projectId)
        {
            return $"/projects/{projectId}/distributions";
        }

        private static string FormUrl_Distribution(int projectId, string hash)
        {
            return $"/projects/{projectId}/distributions/{hash}";
        }

        private static string FormUrl_DistributionRelease(int projectId, string hash)
        {
            return $"/projects/{projectId}/distributions/{hash}/release";
        }

        #endregion
    }
}