﻿
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.MachineTranslationEngines
{
    public class MachineTranslationEnginesApiExecutor
    {
        private const string BaseUrl = "/mts";
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public MachineTranslationEnginesApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public MachineTranslationEnginesApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        [PublicAPI]
        public async Task<ResponseList<MtEngine>> ListMts(int? groupId = null, int limit = 25, int offset = 0)
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.AddParamIfPresent("groupId", groupId);
            
            CrowdinApiResult result = await _apiClient.SendGetRequest(BaseUrl, queryParams);
            return _jsonParser.ParseResponseList<MtEngine>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<MtEngine> AddMt(AddMtEngineRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest(BaseUrl, request);
            return _jsonParser.ParseResponseObject<MtEngine>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<MtEngine> GetMt(int mtId)
        {
            string url = FormUrl_MtId(mtId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<MtEngine>(result.JsonObject);
        }

        [PublicAPI]
        public async Task DeleteMt(int mtId)
        {
            string url = FormUrl_MtId(mtId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Machine Translation Engine {mtId} removal failed");
        }

        [PublicAPI]
        public async Task<MtEngine> EditMt(int mtId, IEnumerable<MtEnginePatch> patches)
        {
            string url = FormUrl_MtId(mtId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<MtEngine>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_MtId(int mtId) => $"{BaseUrl}/{mtId}";

        #endregion
    }
}