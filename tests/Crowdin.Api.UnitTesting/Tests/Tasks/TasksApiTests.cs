
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.Labels;
using Crowdin.Api.Languages;
using Crowdin.Api.Tasks;

using TaskStatus = Crowdin.Api.Tasks.TaskStatus;

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

        [Fact]
        public async Task GetTask()
        {
            const int projectId = 1, taskId = 2;
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/tasks/{taskId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Tasks.GetTask_Response)
                });
            
            var executor = new TasksApiExecutor(mockClient.Object);
            TaskResource response = await executor.GetTask(projectId, taskId);
            
            Assert_TaskResource(response);
        }

        private static void Assert_TaskResource(TaskResource? task)
        {
            ArgumentNullException.ThrowIfNull(task);
            
            Assert.Equal(2, task.Id);
            Assert.Equal(2, task.ProjectId);
            Assert.Equal(6, task.CreatorId);
            Assert.Equal(1, task.Type);
            Assert.Equal(TaskStatus.Todo, task.Status);
            Assert.Equal("French", task.Title);
            Assert.Equal(1, task.BatchId);

            TaskAssignee assignee = task.Assignees.First();
            ArgumentNullException.ThrowIfNull(assignee);
            Assert.Equal(12, assignee.Id);
            Assert.Equal("john_smith", assignee.UserName);
            Assert.Equal("John Smith", assignee.FullName);
            Assert.Empty(assignee.AvatarUrl);
            Assert.Equal(5, assignee.WordsCount);
            Assert.Equal(3, assignee.WordsLeft);

            TaskAssignedTeam assignedTeam = task.AssignedTeams.First();
            ArgumentNullException.ThrowIfNull(assignedTeam);
            Assert.Equal(1, assignedTeam.Id);
            Assert.Equal(5, assignedTeam.WordsCount);

            TaskProgress progress = task.Progress;
            ArgumentNullException.ThrowIfNull(progress);
            Assert.Equal(24, progress.Total);
            Assert.Equal(15, progress.Done);
            Assert.Equal(62, progress.Percent);
            
            TaskProgress translateProgress = task.TranslateProgress;
            ArgumentNullException.ThrowIfNull(translateProgress);
            Assert.Equal(24, translateProgress.Total);
            Assert.Equal(15, translateProgress.Done);
            Assert.Equal(62, translateProgress.Percent);

            Assert.Equal("en", task.SourceLanguageId);
            Assert.Equal("fr", task.TargetLanguageId);
            Assert.Equal("Proofread all French strings", task.Description);
            Assert.Equal("/proofread/9092638ac9f2a2d1b5571d08edc53763/all/en-fr/10?task=dac37aff364d83899128e68afe0de4994", task.TranslationUrl);
            Assert.Equal("https://crowdin.com/project/example-project/tasks/1", task.WebUrl);
            Assert.Equal(24, task.WordsCount);
            Assert.Equal(0, task.CommentsCount);

            DateTimeOffset date = DateTimeOffset.Parse("2019-09-27T07:00:14+00:00");
            Assert.Equal(date, task.DeadLine);
            Assert.Equal(date, task.StartedAt);
            Assert.Equal(date, task.ResolvedAt);
            
            Assert.Equal("2019-08-23T09:04:29+00:00|2019-07-23T09:04:29+00:00", task.TimeRange);
            Assert.Equal(10, task.WorkFlowStepId);
            Assert.Equal("https://www.paypal.com/cgi-bin/webscr?cmd=...", task.BuyUrl);

            date = DateTimeOffset.Parse("2019-09-23T09:04:29+00:00");
            Assert.Equal(date, task.CreatedAt);
            Assert.Equal(date, task.UpdatedAt);
            
            Assert_Language(task.SourceLanguage);
            Assert_Language(task.TargetLanguages.First());
            
            Assert.Equal([13, 27], task.LabelIds);
            Assert.Equal(LabelMatchRule.All, task.LabelMatchRule);
            Assert.Equal([5, 8], task.ExcludeLabelIds);
            Assert.Equal(LabelMatchRule.All, task.ExcludeLabelMatchRule);
            Assert.Equal(1, task.PrecedingTaskId);
            
            Assert_TaskCost(task.EstimatedCost);
            Assert_TaskCost(task.ActualCost);
            
            Assert.Equal("gengo", task.Vendor);
            Assert.Equal(3, task.FilesCount);
            Assert.Equal([24, 25, 38], task.FileIds);
        }

        private static void Assert_Language(Language? language)
        {
            ArgumentNullException.ThrowIfNull(language);
            
            Assert.Equal("es", language.Id);
            Assert.Equal("Spanish", language.Name);
            Assert.Equal("es", language.EditorCode);
            Assert.Equal("es", language.TwoLettersCode);
            Assert.Equal("spa", language.ThreeLettersCode);
            Assert.Equal("es-ES", language.Locale);
            Assert.Equal("es-rES", language.AndroidCode);
            Assert.Equal("es.lproj", language.OsxCode);
            Assert.Equal("es", language.OsxLocale);
            Assert.Equal("one", language.PluralCategoryNames.First());
            Assert.Equal("(n != 1)", language.PluralRules);
            Assert.Equal("0, 2-999; 1.2, 2.07...", language.PluralExamples.First());
            Assert.Equal(TextDirection.LeftToRight, language.TextDirection);
            Assert.Equal("es", language.DialectOf);
        }

        private static void Assert_TaskCost(TaskCost? taskCost)
        {
            ArgumentNullException.ThrowIfNull(taskCost);
            
            Assert.Equal(24.12f, taskCost.Cost);
            Assert.Equal(DateTimeOffset.Parse("2019-09-23T09:04:29+00:00"), taskCost.Date);
            Assert.Equal(Currency.USD, taskCost.Currency);
        }
    }
}