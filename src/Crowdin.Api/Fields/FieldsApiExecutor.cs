
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Core;

namespace Crowdin.Api.Fields
{
    public class FieldsApiExecutor : IFieldsApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public FieldsApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public FieldsApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        /// <summary>
        /// List Fields. Documentation:
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.fields.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public Task<ResponseList<Field>> ListFields(string? search, FieldEntity? entity, FieldType? type,
            int limit = 25,
            int offset = 0)
        {
            return ListFields(new FieldsListParams(limit, offset, search, entity, type));
        }

        /// <summary>
        /// List Fields. Documentation:
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.fields.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<Field>> ListFields(FieldsListParams @params)
        {
            string url = FormUrl_Fields();
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<Field>(result.JsonObject);
        }

        /// <summary>
        /// Add Field. Documentation:
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.fields.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Field> AddField(AddFieldRequest request)
        {
            string url = FormUrl_Fields();
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<Field>(result.JsonObject);
        }

        /// <summary>
        /// Get Field. Documentation:
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.fields.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Field> GetField(int fieldId)
        {
            string url = FormUrl_FieldId(fieldId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Field>(result.JsonObject);
        }

        /// <summary>
        /// Delete Field. Documentation:
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.fields.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteField(int fieldId)
        {
            string url = FormUrl_FieldId(fieldId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Field {fieldId} removal failed.");
        }

        /// <summary>
        /// Edit Field. Documentation:
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.fields.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Field> EditField(int fieldId, IEnumerable<FieldPatch> patches)
        {
            string url = FormUrl_FieldId(fieldId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Field>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_Fields() => "/fields";

        private static string FormUrl_FieldId(int fieldId) => $"/fields/{fieldId}";

        #endregion
    }
}