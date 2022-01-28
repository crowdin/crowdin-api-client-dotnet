
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

        /// <summary>
        /// List dictionaries. Documentation: 
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.dictionaries.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.dictionaries.getMany">Crowdin Enterprise API</a>
        /// </summary>
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

        /// <summary>
        /// Edit dictionary. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.dictionaries.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.dictionaries.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Dictionary> EditDictionary(int projectId, string languageId, IEnumerable<DictionaryPatch> patches)
        {
            var url = $"/projects/{projectId}/dictionaries/{languageId}";
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Dictionary>(result.JsonObject);
        }
    }
}