using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.Tasks;
using Crowdin.Api.UnitTesting.Resources;

using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

using CrowdinTaskStatus = Crowdin.Api.Tasks.TaskStatus;
using TaskFixtures = Crowdin.Api.UnitTesting.Resources.Tasks;

namespace Crowdin.Api.UnitTesting.Tests.Tasks
{
    public class OrganizationTasksApiTests
    {
        [Fact]
        public async Task ListOrganizationTasksUsesFiltersAndParsesTaskFields()
        {
            var @params = new OrganizationTasksListParams
            {
                Limit = 10,
                Offset = 2,
                Statuses = new[] { CrowdinTaskStatus.InProgress },
                Types = new[] { TaskType.Translate },
                ProjectIds = new long[] { 7 }
            };
            IDictionary<string, string> queryParams = new Dictionary<string, string>
            {
                ["limit"] = "10",
                ["offset"] = "2",
                ["status"] = "in_progress",
                ["type"] = "0",
                ["projectIds"] = "7"
            };
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient.Setup(client => client.SendGetRequest("/tasks", queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(TaskFixtures.OrganizationTaskList_Response)
                });

            var executor = new TasksApiExecutor(mockClient.Object);
            ResponseList<TaskResource> response = await executor.ListOrganizationTasks(@params);

            Assert.Single(response.Data);
            TaskResource task = response.Data[0];
            Assert.Equal(501, task.Id);
            Assert.Equal(7, task.ProjectId);
            Assert.Equal("Translate onboarding", task.Title);
            Assert.Equal(CrowdinTaskStatus.InProgress, task.Status);
            Assert.Equal(120, task.WordsCount);
            Assert.Equal(140, task.OriginalWordsCount);
            Assert.Equal(62, task.Progress.Percent);
            Assert.Equal("uk", task.TargetLanguageId);
            Assert.Equal(44, task.ReportSettingsTemplateId);
            Assert.Equal("high", task.Fields!["priority"]!.Value<string>());
        }
    }
}
