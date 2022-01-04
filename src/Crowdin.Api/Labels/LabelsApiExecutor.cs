
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.SourceStrings;
using JetBrains.Annotations;

namespace Crowdin.Api.Labels
{
    public class LabelsApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public LabelsApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }
        
        public LabelsApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        [PublicAPI]
        public async Task<ResponseList<Label>> ListLabels(int projectId, int limit = 25, int offset = 0)
        {
            string url = FormUrl_Labels(projectId);
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<Label>(result.JsonObject);
        }

        [PublicAPI]
        public Task<Label> AddLabel(int projectId, string title)
        {
            return AddLabel(projectId, new AddLabelRequest { Title = title });
        }

        [PublicAPI]
        public async Task<Label> AddLabel(int projectId, AddLabelRequest request)
        {
            string url = FormUrl_Labels(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<Label>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<Label> GetLabel(int projectId, int labelId)
        {
            string url = FormUrl_LabelId(projectId, labelId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Label>(result.JsonObject);
        }

        [PublicAPI]
        public async Task DeleteLabel(int projectId, int labelId)
        {
            string url = FormUrl_LabelId(projectId, labelId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Label {labelId} removal failed");
        }

        [PublicAPI]
        public Task<Label> EditLabel(int projectId, int labelId, string title)
        {
            var patches = new[]
            {
                new LabelPatch { Value = title }
            };

            return EditLabel(projectId, labelId, patches);
        }

        [PublicAPI]
        public async Task<Label> EditLabel(int projectId, int labelId, IEnumerable<LabelPatch> patches)
        {
            string url = FormUrl_LabelId(projectId, labelId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Label>(result.JsonObject);
        }

        [PublicAPI]
        public Task<ResponseList<SourceString>> AssignLabelToStrings(
            int projectId, int labelId, ICollection<int> stringIds)
        {
            var request = new AssignLabelToStringsRequest
            {
                StringIds = stringIds
            };

            return AssignLabelToStrings(projectId, labelId, request);
        }

        [PublicAPI]
        public async Task<ResponseList<SourceString>> AssignLabelToStrings(
            int projectId, int labelId, AssignLabelToStringsRequest request)
        {
            string url = FormUrl_LabelStrings(projectId, labelId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseList<SourceString>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<ResponseList<SourceString>> UnassignLabelFromStrings(
            int projectId, int labelId, ICollection<int> stringIds)
        {
            string url = FormUrl_LabelStrings(projectId, labelId);

            var queryParams = new Dictionary<string, string>
            {
                { "stringIds", string.Join(",", stringIds) }
            };

            CrowdinApiResult result = await _apiClient.SendDeleteRequest_FullResult(url, queryParams);
            return _jsonParser.ParseResponseList<SourceString>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_Labels(int projectId)
        {
            return $"/projects/{projectId}/labels";
        }

        private static string FormUrl_LabelId(int projectId, int labelId)
        {
            return $"/projects/{projectId}/labels/{labelId}";
        }

        private static string FormUrl_LabelStrings(int projectId, int labelId)
        {
            return $"/projects/{projectId}/labels/{labelId}/strings";
        }

        #endregion
    }
}