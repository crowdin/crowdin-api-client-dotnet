using Crowdin.Api.Core;
using Crowdin.Api.Screenshots;
using Crowdin.Api.Tasks;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace Crowdin.Api.UnitTesting.Tests.Tasks
{
    public class TasksApiTests
    {
        private static readonly JsonSerializerSettings Settings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public void AddTask_VendorGengo_RequestSerialization_ToneNotSet()
        {
            var request = new VendorGengoTaskCreateForm
            {
                Type = TaskType.TranslateByVendor,
                Tone = VendorGengoTaskCreateForm.TaskTone.NotSet
            };

            string requestJson = JsonConvert.SerializeObject(request, Settings);
            Assert.NotNull(requestJson);
            Assert.Equal(Resources.Tasks.AddTask_RightRequestJson_VendorGengo_ToneNotSet, requestJson);
        }

        [Fact]
        public void AddTask_VendorGengo_RequestSerialization_ToneInformal()
        {
            var request = new VendorGengoTaskCreateForm
            {
                Type = TaskType.TranslateByVendor,
                Tone = VendorGengoTaskCreateForm.TaskTone.Informal
            };

            string requestJson = JsonConvert.SerializeObject(request, Settings);
            Assert.NotNull(requestJson);
            Assert.Equal(Resources.Tasks.AddTask_RightRequestJson_VendorGengo_ToneInformal, requestJson);
        }

        [Fact]
        public void AddTask_VendorGengo_RequestSerialization_ToneOther()
        {
            var request = new VendorGengoTaskCreateForm
            {
                Type = TaskType.TranslateByVendor,
                Tone = VendorGengoTaskCreateForm.TaskTone.Other
            };

            string requestJson = JsonConvert.SerializeObject(request, Settings);
            Assert.NotNull(requestJson);
            Assert.Equal(Resources.Tasks.AddTask_RightRequestJson_VendorGengo_ToneOther, requestJson);
        }

        [Fact]
        public void AddTask_VendorManual_RequestSerialization()
        {
            var request = new VendorManualTaskCreateForm
            {
                Title = "My task",
                LanguageId = "es",
                FileIds = new[] { 1, 2, 3 },
                Type = TaskType.TranslateByVendor,
                Vendor = TaskVendor.Lingo24,
                Status = TaskStatus.InProgress,
                Description = "My amazing task",
                SkipAssignedStrings = true,
                SkipUntranslatedStrings = true,
                LabelIds = new[] { 1 },
                Assignees = new[]
                {
                    new TaskAssigneeForm { Id = 1, WordsCount = 20 },
                    new TaskAssigneeForm { Id = 2, WordsCount = 30 }
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, Settings);
            string expectedRequestJson = TestUtils.CompactJson(Resources.Tasks.AddTask_RightRequestJson_VendorManual);
            Assert.Equal(expectedRequestJson, actualRequestJson);
        }

        [Fact]
        public async System.Threading.Tasks.Task ListTasks()
        {
            const int projectId = 1;

            var url = $"/projects/{projectId}/tasks";

            var queryParams = new Dictionary<string, string>
            {
                { "limit", "25" },
                { "offset", "0" },
                { "status", "todo,in_progress" },
                { "assigneeId", "1" },
                { "orderBy", "createdAt desc,name asc" },

            };

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Tasks.ListTasks)
                });

            var executor = new TasksApiExecutor(mockClient.Object);
            var statuses = new TaskStatus[] { TaskStatus.Todo, TaskStatus.InProgress };
            var assigneeId = 1;
            var sortingRules = new SortingRule[] {
                new SortingRule() { Field = "createdAt", Order = SortingOrder.Descending },
                new SortingRule() { Field = "name", Order = SortingOrder.Ascending }
            };

            var response = await executor.ListTasks(projectId, 25, 0, statuses, assigneeId, sortingRules);

            Assert.NotNull(response);

            Assert.Equal(25, response.Pagination?.Limit);
            Assert.Equal(0, response.Pagination?.Offset);

            Assert.Single(response.Data);
            Assert.Equal(2, response.Data[0].Id);
        }
    }
}