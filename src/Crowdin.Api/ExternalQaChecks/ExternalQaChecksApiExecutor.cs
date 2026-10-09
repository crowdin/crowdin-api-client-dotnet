#nullable enable

using System.Collections.Generic;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.ExternalQaChecks
{
    public class ExternalQaChecksApiExecutor : IExternalQaChecksApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public ExternalQaChecksApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public ExternalQaChecksApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        /// <summary>
        /// List external QA checks. Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#operation/api.external-qa-checks.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<ExternalQaCheck>> ListExternalQaChecks(ExternalQaChecksListParams? @params = null)
        {
            IDictionary<string, string> queryParams = @params?.ToQueryParams() ?? Utils.CreateQueryParamsFromPaging(25, 0);
            CrowdinApiResult result = await _apiClient.SendGetRequest("/external-qa-checks", queryParams);
            return _jsonParser.ParseResponseList<ExternalQaCheck>(result.JsonObject);
        }

        /// <summary>
        /// Get an external QA check. Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#operation/api.external-qa-checks.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ExternalQaCheck> GetExternalQaCheck(long externalQaCheckId)
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest($"/external-qa-checks/{externalQaCheckId}");
            return _jsonParser.ParseResponseObject<ExternalQaCheck>(result.JsonObject);
        }
    }
}
