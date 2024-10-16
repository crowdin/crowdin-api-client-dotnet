
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.Tasks;
using Crowdin.Api.Tests.Testing;
using Crowdin.Api.Tests.Testing.Resources;

namespace Crowdin.Api.Tests.Tasks
{
    public class TaskSettingsTemplatesApiTests
    {
        private static readonly JsonSerializerSettings Settings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task ListTaskSettingsTemplates()
        {
            const int projectId = 1;
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/tasks/settings-templates";
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Tasks_SettingsTemplates.ListTaskSettingsTemplates_Response)
                });

            var executor = new TasksApiExecutor(mockClient.Object);
            ResponseList<TaskSettingsTemplate> response = await executor.ListTaskSettingsTemplates(projectId);
            
            Assert.NotNull(response);
            Assert.Single(response.Data);
            Assert.Single(response.Data[0].Config?.Languages!);

            LanguageReference? selector = response.Data[0].Config?.Languages[0];
            Assert.NotNull(selector);
            Assert.Equal("uk", selector!.LanguageId);
            Assert.Equal(1, selector!.UserIds?[0]);
            Assert.Equal(1, selector!.TeamIds?[0]);
        }

        [Fact]
        public async Task AddTaskSettingsTemplate()
        {
            const int projectId = 1;

            var request = new AddTaskSettingsTemplate
            {
                Name = "Default template",
                Config = new TaskSettingsTemplateConfigForm
                {
                    Languages = new[]
                    {
                        new LanguageReference
                        {
                            LanguageId = "uk",
                            UserIds = new[] { 1 },
                            TeamIds = new[] { 1 }
                        }
                    }
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, Settings);
            string expectedRequestJson = TestUtils.CompactJson(Tasks_SettingsTemplates.AddTaskSettingsTemplates_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/tasks/settings-templates";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Tasks_SettingsTemplates.Shared_SingleItem_Response)
                });

            var executor = new TasksApiExecutor(mockClient.Object);
            TaskSettingsTemplate response = await executor.AddTaskSettingsTemplate(projectId, request);
            
            Assert.NotNull(response);
            Assert.Equal(1, response.Config.Languages[0].UserIds![0]);
        }

        [Fact]
        public async Task GetTaskSettingsTemplate()
        {
            const int projectId = 1;
            const int taskSettingsTemplateId = 1;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/tasks/settings-templates/{taskSettingsTemplateId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Tasks_SettingsTemplates.Shared_SingleItem_Response)
                });

            var executor = new TasksApiExecutor(mockClient.Object);
            TaskSettingsTemplate response = await executor.GetTaskSettingsTemplate(projectId, taskSettingsTemplateId);
            
            Assert.NotNull(response);
            Assert.Equal(1, response.Config.Languages[0]!.UserIds![0]);
            Assert.Equal(1, response.Config.Languages[0]!.TeamIds![0]);
        }

        [Fact]
        public async Task EditTaskSettingsTemplate()
        {
            const int projectId = 1;
            const int taskSettingsTemplateId = 1;

            var patches = new[]
            {
                new TaskSettingsTemplatePatch
                {
                    Operation = PatchOperation.Replace,
                    Path = TaskSettingsTemplatePatchPath.Name,
                    Value = "New name"
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(patches, Settings);
            string expectedRequestJson = TestUtils.CompactJson(Tasks_SettingsTemplates.EditTaskSettingsTemplate_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/tasks/settings-templates/{taskSettingsTemplateId}";

            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Tasks_SettingsTemplates.Shared_SingleItem_Response)
                });

            var executor = new TasksApiExecutor(mockClient.Object);
            TaskSettingsTemplate response = await executor.EditTaskSettingsTemplate(projectId, taskSettingsTemplateId, patches);
            
            Assert.NotNull(response);
            Assert.Equal(1, response.Config.Languages[0]!.TeamIds![0]);
        }
    }
}