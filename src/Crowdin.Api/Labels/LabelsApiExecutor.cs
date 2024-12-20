
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Core;
using Crowdin.Api.Screenshots;
using Crowdin.Api.SourceStrings;

#nullable enable

namespace Crowdin.Api.Labels
{
    public class LabelsApiExecutor : ILabelsApiExecutor
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

        /// <summary>
        /// List labels. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.labels.getMany">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.projects.labels.getMany">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.labels.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<Label>> ListLabels(
            int projectId,
            int limit = 25,
            int offset = 0,
            bool? isSystem = null,
            IEnumerable<SortingRule>? orderBy = null)
        {
            string url = FormUrl_Labels(projectId);
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.AddParamIfPresent("isSystem", isSystem);
            queryParams.AddSortingRulesIfPresent(orderBy);
            
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<Label>(result.JsonObject);
        }

        /// <summary>
        /// Add label. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.labels.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.labels.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public Task<Label> AddLabel(int projectId, string title)
        {
            return AddLabel(projectId, new AddLabelRequest { Title = title });
        }

        /// <summary>
        /// Add label. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.labels.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.labels.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Label> AddLabel(int projectId, AddLabelRequest request)
        {
            string url = FormUrl_Labels(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<Label>(result.JsonObject);
        }

        /// <summary>
        /// Get label. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.labels.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.labels.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Label> GetLabel(int projectId, int labelId)
        {
            string url = FormUrl_LabelId(projectId, labelId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Label>(result.JsonObject);
        }

        /// <summary>
        /// Delete label. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.labels.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.labels.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteLabel(int projectId, int labelId)
        {
            string url = FormUrl_LabelId(projectId, labelId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Label {labelId} removal failed");
        }

        /// <summary>
        /// Edit label. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.labels.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.labels.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Label> EditLabel(int projectId, int labelId, IEnumerable<LabelPatch> patches)
        {
            string url = FormUrl_LabelId(projectId, labelId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Label>(result.JsonObject);
        }

        /// <summary>
        /// Assign label to strings. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.labels.strings.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.labels.strings.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public Task<ResponseList<SourceString>> AssignLabelToStrings(
            int projectId,
            int labelId,
            ICollection<int> stringIds)
        {
            var request = new AssignLabelToStringsRequest
            {
                StringIds = stringIds
            };

            return AssignLabelToStrings(projectId, labelId, request);
        }

        /// <summary>
        /// Assign label to strings. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.labels.strings.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.labels.strings.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<SourceString>> AssignLabelToStrings(
            int projectId,
            int labelId,
            AssignLabelToStringsRequest request)
        {
            string url = FormUrl_LabelStrings(projectId, labelId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseList<SourceString>(result.JsonObject);
        }

        /// <summary>
        /// Unassign label from strings. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.labels.strings.deleteMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.labels.strings.deleteMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<SourceString>> UnassignLabelFromStrings(
            int projectId,
            int labelId,
            ICollection<int> stringIds)
        {
            string url = FormUrl_LabelStrings(projectId, labelId);

            var queryParams = new Dictionary<string, string>
            {
                { "stringIds", string.Join(",", stringIds) }
            };

            CrowdinApiResult result = await _apiClient.SendDeleteRequest_FullResult(url, queryParams);
            return _jsonParser.ParseResponseList<SourceString>(result.JsonObject);
        }

        /// <summary>
        /// Assign Label to Screenshots. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.labels.screenshots.post">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.labels.screenshots.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<Screenshot>> AssignLabelToScreenshots(
            int projectId,
            int labelId,
            AssignLabelToScreenshotsRequest request)
        {
            string url = FormUrl_LabelScreenshots(projectId, labelId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseList<Screenshot>(result.JsonObject);
        }

        /// <summary>
        /// Unassign Label from Screenshots. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.labels.screenshots.deleteMany">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.labels.screenshots.deleteMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<Screenshot>> UnassignLabelFromScreenshots(
            int projectId,
            int labelId,
            IEnumerable<int> screenshotIds)
        {
            string url = FormUrl_LabelScreenshots(projectId, labelId);
            
            var queryParams = new Dictionary<string, string>
            {
                { "screenshotIds", string.Join(",", screenshotIds) }
            };

            CrowdinApiResult result = await _apiClient.SendDeleteRequest_FullResult(url, queryParams);
            return _jsonParser.ParseResponseList<Screenshot>(result.JsonObject);
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

        private static string FormUrl_LabelScreenshots(int projectId, int labelId)
        {
            return $"/projects/{projectId}/labels/{labelId}/screenshots";
        }

        #endregion
    }
}