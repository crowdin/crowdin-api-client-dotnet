
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.Storage
{
    public class StorageApiExecutor
    {
        private const string BaseSubUrl = "/storages";
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public StorageApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public StorageApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }
        
        [PublicAPI]
        public async Task<ResponseList<StorageResource>> ListStorages(int limit = 25, int offset = 0)
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            CrowdinApiResult result = await _apiClient.SendGetRequest(BaseSubUrl, queryParams);
            return _jsonParser.ParseResponseList<StorageResource>(result.JsonObject);
        }
        
        [PublicAPI]
        public async Task<StorageResource> AddStorage(Stream fileStream, string filename)
        {
            CrowdinApiResult result = await _apiClient.UploadFile(BaseSubUrl, filename, fileStream);
            return _jsonParser.ParseResponseObject<StorageResource>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<StorageResource> GetStorage(int storageId)
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest(FormUrlWithId(storageId));
            return _jsonParser.ParseResponseObject<StorageResource>(result.JsonObject);
        }

        [PublicAPI]
        public async Task DeleteStorage(int storageId)
        {
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(FormUrlWithId(storageId));
            Utils.ThrowIfStatusNot204(statusCode, $"Storage {storageId} removal failed");
        }

        private static string FormUrlWithId(int storageId) => $"{BaseSubUrl}/{storageId}";
    }
}