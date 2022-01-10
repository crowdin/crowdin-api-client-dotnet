
using System.Collections.Generic;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.Dictionaries
{
    public class DictionariesApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public DictionariesApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public DictionariesApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        [PublicAPI]
        public async Task<ResponseList<Dictionary>> ListDictionaries(int projectId, string? languageIds = null)
        {
            var url = $"/projects/{projectId}/dictionaries";
            
            IDictionary<string, string>? queryParams =
                !string.IsNullOrWhiteSpace(languageIds)
                    ? new Dictionary<string, string>
                    {
                        { "languageIds", languageIds! }
                    }
                    : null;

            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<Dictionary>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<Dictionary> EditDictionary(int projectId, string languageId, IEnumerable<DictionaryPatch> patches)
        {
            var url = $"/projects/{projectId}/dictionaries/{languageId}";
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Dictionary>(result.JsonObject);
        }
    }
}