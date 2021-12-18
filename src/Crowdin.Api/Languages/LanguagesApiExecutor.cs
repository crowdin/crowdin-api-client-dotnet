
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.Languages
{
    public class LanguagesApiExecutor
    {
        private const string BaseSubUrl = "/languages";
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public LanguagesApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public LanguagesApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }
        
        [PublicAPI]
        public async Task<ResponseList<Language>> ListSupportedLanguages(int limit = 25, int offset = 0)
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            CrowdinApiResult result = await _apiClient.SendGetRequest(BaseSubUrl, queryParams);
            
            return _jsonParser.ParseResponseList<Language>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<Language> AddCustomLanguage(AddCustomLanguageRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest(BaseSubUrl, request);
            
            return _jsonParser.ParseResponseObject<Language>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<Language> GetLanguage(string languageId)
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest(FormUrlWithId(languageId));
            return _jsonParser.ParseResponseObject<Language>(result.JsonObject);
        }

        [PublicAPI]
        public async Task DeleteCustomLanguage(string languageId)
        {
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(FormUrlWithId(languageId));
            Utils.ThrowIfStatusNot204(statusCode, $"Language {languageId} removal failed");
        }

        [PublicAPI]
        public async Task<Language> EditCustomLanguage(string languageId, IEnumerable<LanguagePatch> patches)
        {
            CrowdinApiResult result = await _apiClient.SendPatchRequest(FormUrlWithId(languageId), patches);
            return _jsonParser.ParseResponseObject<Language>(result.JsonObject);
        }

        private static string FormUrlWithId(string languageId) => $"{BaseSubUrl}/{languageId}";
    }
}