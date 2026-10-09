#nullable enable

using System.Collections.Generic;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.CustomSpellcheckers
{
    public class CustomSpellcheckersApiExecutor : ICustomSpellcheckersApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public CustomSpellcheckersApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public CustomSpellcheckersApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        /// <summary>
        /// List custom spellcheckers. Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#operation/api.custom-spellcheckers.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<CustomSpellchecker>> ListCustomSpellcheckers(int limit = 25, int offset = 0)
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            CrowdinApiResult result = await _apiClient.SendGetRequest("/custom-spellcheckers", queryParams);
            return _jsonParser.ParseResponseList<CustomSpellchecker>(result.JsonObject);
        }

        /// <summary>
        /// Get a custom spellchecker. Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#operation/api.custom-spellcheckers.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<CustomSpellchecker> GetCustomSpellchecker(long customSpellcheckerId)
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest($"/custom-spellcheckers/{customSpellcheckerId}");
            return _jsonParser.ParseResponseObject<CustomSpellchecker>(result.JsonObject);
        }
    }
}
