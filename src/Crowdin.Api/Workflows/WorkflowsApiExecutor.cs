
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Abstractions;
using Crowdin.Api.Core;

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