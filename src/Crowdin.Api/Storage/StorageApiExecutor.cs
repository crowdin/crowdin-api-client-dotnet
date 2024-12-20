
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.Storage
{
    public class StorageApiExecutor : IStorageApiExecutor
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
        
        /// <summary>
        /// List storages. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.storages.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.storages.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<StorageResource>> ListStorages(int limit = 25, int offset = 0)
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            CrowdinApiResult result = await _apiClient.SendGetRequest(BaseSubUrl, queryParams);
            return _jsonParser.ParseResponseList<StorageResource>(result.JsonObject);
        }
        
        /// <summary>
        /// Add storage. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.storages.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.storages.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<StorageResource> AddStorage(Stream fileStream, string filename)
        {
            CrowdinApiResult result = await _apiClient.UploadFile(BaseSubUrl, filename, fileStream);
            return _jsonParser.ParseResponseObject<StorageResource>(result.JsonObject);
        }

        /// <summary>
        /// Get storage. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.storages.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.storages.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<StorageResource> GetStorage(long storageId)
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest(FormUrlWithId(storageId));
            return _jsonParser.ParseResponseObject<StorageResource>(result.JsonObject);
        }

        /// <summary>
        /// Delete storage. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.storages.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.storages.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteStorage(long storageId)
        {
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(FormUrlWithId(storageId));
            Utils.ThrowIfStatusNot204(statusCode, $"Storage {storageId} removal failed");
        }

        private static string FormUrlWithId(long storageId) => $"{BaseSubUrl}/{storageId}";
    }
}