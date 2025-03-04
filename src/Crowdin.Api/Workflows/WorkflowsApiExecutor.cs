
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Core;
using Crowdin.Api.SourceStrings;

#nullable enable

namespace Crowdin.Api.Workflows
{
    public class WorkflowsApiExecutor : IWorkflowsApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public WorkflowsApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public WorkflowsApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        #region Steps
        
        /// <summary>
        /// List Workflow Steps. Documentation:
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.workflow-steps.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<WorkflowStep>> ListWorkflowSteps(int projectId)
        {
            var url = $"/projects/{projectId}/workflow-steps";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseList<WorkflowStep>(result.JsonObject);
        }
        
        /// <summary>
        /// Get Workflow Step. Documentation:
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.workflow-steps.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<WorkflowStep> GetWorkflowStep(int projectId, int stepId)
        {
            var url = $"/projects/{projectId}/workflow-steps/{stepId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<WorkflowStep>(result.JsonObject);
        }

        /// <summary>
        /// List Strings on the Workflow Step. Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Workflows/operation/api.projects.workflow-steps.strings.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public Task<ResponseList<SourceString>> ListStringsOnTheWorkflowStep(
            int projectId,
            int stepId,
            IEnumerable<string>? languageIds = null,
            IEnumerable<SortingRule>? orderBy = null,
            WorkflowStatus? status = null,
            int? limit = null,
            int? offset = null)
        {
            return ListStringsOnTheWorkflowStep(
                projectId, stepId,
                new StringsOnTheWorkflowStepListParams
                {
                    LanguageIds = languageIds,
                    OrderBy = orderBy,
                    Status = status,
                    Limit = limit.GetValueOrDefault(25),
                    Offset = offset.GetValueOrDefault(0)
                });
        }

        /// <summary>
        /// List Strings on the Workflow Step. Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Workflows/operation/api.projects.workflow-steps.strings.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<SourceString>> ListStringsOnTheWorkflowStep(
            int projectId,
            int stepId,
            StringsOnTheWorkflowStepListParams? @params = null)
        {
            var url = $"/projects/{projectId}/workflow-steps/{stepId}/strings";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params?.ToQueryParams());
            return _jsonParser.ParseResponseList<SourceString>(result.JsonObject);
        }

        #endregion

        #region Templates
        
        /// <summary>
        /// List Workflow Templates. Documentation:
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.workflow-templates.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<WorkflowTemplate>> ListWorkflowTemplates(int groupId, int limit = 25, int offset = 0)
        {
            const string url = "/workflow-templates";
            
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.Add("groupId", groupId.ToString());
            
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<WorkflowTemplate>(result.JsonObject);
        }
        
        /// <summary>
        /// Get Workflow Template. Documentation:
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.workflow-templates.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<WorkflowTemplate> GetWorkflowTemplate(int templateId)
        {
            var url = $"/workflow-templates/{templateId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<WorkflowTemplate>(result.JsonObject);
        }

        #endregion
    }
}