
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
using Crowdin.Api.Tasks;
using Crowdin.Api.UnitTesting.Resources;

namespace Crowdin.Api.UnitTesting.Tests.Tasks
{
    public class TaskCommentsApiTests
    {
        private static readonly JsonSerializerSettings Settings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task ListTaskComments()
        {
            const int projectId = 1;
            const int taskId = 2;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/tasks/{taskId}/comments";

            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Tasks_Comments.ListTaskComments_Response)
                });

            var executor = new TasksApiExecutor(mockClient.Object);
            ResponseList<TaskComment> response = await executor.ListTaskComments(projectId, taskId);
            
            Assert_TaskComment(response.Data.Single());
        }

        [Fact]
        public async Task AddTaskComment()
        {
            const int projectId = 1;
            const int taskId = 2;

            var request = new AddTaskCommentRequest
            {
                Text = "Work in task",
                TimeSpent = 3600
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, Settings);
            string expectedRequestJson = TestUtils.CompactJson(Tasks_Comments.AddTaskComment_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/projects/{projectId}/tasks/{taskId}/comments";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Tasks_Comments.CommonResponses_Single)
                });
            
            var executor = new TasksApiExecutor(mockClient.Object);
            TaskComment response = await executor.AddTaskComment(projectId, taskId, request);
            
            Assert_TaskComment(response);
        }

        [Fact]
        public async Task GetTaskComment()
        {
            const int projectId = 1;
            const int taskId = 2;
            const int commentId = 3;
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/projects/{projectId}/tasks/{taskId}/comments/{commentId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Tasks_Comments.CommonResponses_Single)
                });
            
            var executor = new TasksApiExecutor(mockClient.Object);
            TaskComment response = await executor.GetTaskComment(projectId, taskId, commentId);

            Assert_TaskComment(response);
        }

        [Fact]
        public async Task DeleteTaskComment()
        {
            const int projectId = 1;
            const int taskId = 2;
            const int commentId = 3;
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/projects/{projectId}/tasks/{taskId}/comments/{commentId}";

            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);
            
            var executor = new TasksApiExecutor(mockClient.Object);
            await executor.DeleteTaskComment(projectId, taskId, commentId);
        }

        [Fact]
        public async Task EditTaskComment()
        {
            const int projectId = 1;
            const int taskId = 2;
            const int commentId = 3;

            var request = new[]
            {
                new TaskCommentPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = TaskCommentPatchPath.Text,
                    Value = "Work in task"
                },
                new TaskCommentPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = TaskCommentPatchPath.TimeSpent,
                    Value = 3600
                }
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, Settings);
            string expectedRequestJson = TestUtils.CompactJson(Tasks_Comments.EditTaskComment_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/projects/{projectId}/tasks/{taskId}/comments/{commentId}";

            mockClient
                .Setup(client => client.SendPatchRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Tasks_Comments.CommonResponses_Single)
                });
            
            var executor = new TasksApiExecutor(mockClient.Object);
            TaskComment response = await executor.EditTaskComment(projectId, taskId, commentId, request);
            
            Assert_TaskComment(response);
        }

        private static void Assert_TaskComment(TaskComment? comment)
        {
            ArgumentNullException.ThrowIfNull(comment);
            
            Assert.Equal(1233, comment.Id);
            Assert.Equal(5, comment.UserId);
            Assert.Equal(203, comment.TaskId);
            Assert.Equal("translate task", comment.Text);
            Assert.Equal(3600, comment.TimeSpent);

            DateTimeOffset date = DateTimeOffset.Parse("2019-09-23T09:04:29+00:00");
            Assert.Equal(date, comment.CreatedAt);
            Assert.Equal(date, comment.UpdatedAt);
        }
    }
}