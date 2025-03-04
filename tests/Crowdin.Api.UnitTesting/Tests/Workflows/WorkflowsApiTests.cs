
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.SourceStrings;
using Crowdin.Api.Workflows;

namespace Crowdin.Api.UnitTesting.Tests.Workflows
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
                    JsonObject = JObject.Parse(Resources.Workflows.ListWorkflowSteps_Response)
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
                    JsonObject = JObject.Parse(Resources.Workflows.GetWorkflowStep_Response)
                });

            var executor = new WorkflowsApiExecutor(mockClient.Object);
            WorkflowStep? response = await executor.GetWorkflowStep(projectId, stepId);

            Assert.NotNull(response);
            Assert.Equal(WorkflowStepType.Translate, response.Type);
            Assert.IsType<WorkflowTranslationConfig>(response.Config);
        }

        [Fact]
        public async Task ListStringsOnTheWorkflowStep()
        {
            const int projectId = 1, stepId = 2;
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/projects/{projectId}/workflow-steps/{stepId}/strings";

            var queryParams = new Dictionary<string, string>
            {
                ["limit"] = "25",
                ["offset"] = "0",
                ["languageIds"] = "es,it,uk",
                ["orderBy"] = "createdAt desc,text,identifier",
                ["status"] = "pending"
            };

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Workflows.ListStringsOnTheWorkflowStep_Response)
                });
            
            var executor = new WorkflowsApiExecutor(mockClient.Object);
            
            ResponseList<SourceString> response = await executor.ListStringsOnTheWorkflowStep(
                projectId, stepId,
                languageIds: [ "es", "it", "uk" ],
                status: WorkflowStatus.Pending,
                orderBy:
                [
                    new SortingRule
                    {
                        Field = "createdAt",
                        Order = SortingOrder.Descending
                    },
                    new SortingRule
                    {
                        Field = "text"
                    },
                    new SortingRule
                    {
                        Field = "identifier"
                    }
                ]);
            
            Assert.NotNull(response);
            Assert_SourceString(response.Data.First());
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
                    JsonObject = JObject.Parse(Resources.Workflows.ListWorkflowTemplates_Response)
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
                    JsonObject = JObject.Parse(Resources.Workflows.GetWorkflowTemplate_Response)
                });

            var executor = new WorkflowsApiExecutor(mockClient.Object);
            WorkflowTemplate? response = await executor.GetWorkflowTemplate(templateId);

            Assert.NotNull(response);
            Assert.Equal(templateId, response.Id);
        }

        private static void Assert_SourceString(SourceString? sourceString)
        {
            ArgumentNullException.ThrowIfNull(sourceString);
            
            Assert.Equal(2814, sourceString.Id);
            Assert.Equal(2, sourceString.ProjectId);
            Assert.Equal(12, sourceString.BranchId);
            Assert.Equal("name", sourceString.Identifier);
            Assert.Equal("Not all videos are shown to users. See more", sourceString.Text);
            Assert.Equal("text", sourceString.Type);
            Assert.Equal("shown on main page", sourceString.Context);
            Assert.Equal(35, sourceString.MaxLength);
            Assert.False(sourceString.IsHidden);
            Assert.True(sourceString.IsDuplicate);
            Assert.Equal(1, sourceString.MasterStringId);
            Assert.False(sourceString.HasPlurals);
            Assert.False(sourceString.IsIcu);
            Assert.Equal(3, sourceString.LabelIds.First());
            Assert.StartsWith("https://", sourceString.WebUrl);
            Assert.Equal(DateTimeOffset.Parse("2019-09-20T12:43:57+00:00"), sourceString.CreatedAt);
            Assert.Equal(DateTimeOffset.Parse("2019-09-20T13:24:01+00:00"), sourceString.UpdatedAt);
            Assert.Equal(48, sourceString.FileId);
            Assert.Equal(13, sourceString.DirectoryId);
            Assert.Equal(1, sourceString.Revision);
        }
    }
}