
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.Tests.Core;
using Crowdin.Api.Workflows;

namespace Crowdin.Api.Tests.Workflows
{
    public class WorkflowsApiTests
    {
        [Fact]
        public async Task ListWorkflowSteps()
        {
            const int projectId = 1;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/workflow-steps";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Workflows.ListWorkflowSteps_Response)
                });

            var executor = new WorkflowsApiExecutor(mockClient.Object);
            ResponseList<WorkflowStep> response = await executor.ListWorkflowSteps(projectId);
            
            Assert.NotNull(response);
            Assert.Single(response.Data);
            Assert.Equal(WorkflowStepType.Translate, response.Data[0].Type);
            Assert.IsType<WorkflowTranslationConfig>(response.Data[0].Config);
        }

        [Fact]
        public async Task GetWorkflowStep()
        {
            const int projectId = 1, stepId = 2;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/workflow-steps/{stepId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Workflows.GetWorkflowStep_Response)
                });

            var executor = new WorkflowsApiExecutor(mockClient.Object);
            WorkflowStep? response = await executor.GetWorkflowStep(projectId, stepId);
            
            Assert.NotNull(response);
            Assert.Equal(WorkflowStepType.Translate, response.Type);
            Assert.IsType<WorkflowTranslationConfig>(response.Config);
        }

        [Fact]
        public async Task ListWorkflowTemplates()
        {
            const int groupId = 2;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/workflow-templates";

            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            queryParams.Add("groupId", groupId.ToString());

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Workflows.ListWorkflowTemplates_Response)
                });

            var executor = new WorkflowsApiExecutor(mockClient.Object);
            ResponseList<WorkflowTemplate>? response = await executor.ListWorkflowTemplates(groupId);
            
            Assert.NotNull(response);
            Assert.Single(response.Data);
            Assert.Equal(groupId, response.Data[0].GroupId);
        }

        [Fact]
        public async Task GetWorkflowTemplate()
        {
            const int templateId = 2;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/workflow-templates/{templateId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Workflows.GetWorkflowTemplate_Response)
                });

            var executor = new WorkflowsApiExecutor(mockClient.Object);
            WorkflowTemplate? response = await executor.GetWorkflowTemplate(templateId);
            
            Assert.NotNull(response);
            Assert.Equal(templateId, response.Id);
        }
    }
}