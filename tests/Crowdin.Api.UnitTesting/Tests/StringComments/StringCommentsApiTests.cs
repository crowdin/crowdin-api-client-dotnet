
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.StringComments;

namespace Crowdin.Api.UnitTesting.Tests.StringComments
{
    public class StringCommentsApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();
        
        [Fact]
        public void ListStringComments_QueryStringConstruction()
        {
            const string expectedQueryString = "limit=25&offset=0&stringId=123&type=comment&issueType=general_question,translation_mistake&issueStatus=resolved";

            var @params = new StringCommentsListParams
            {
                StringId = 123,
                Type = StringCommentType.Comment,
                IssueStatus = IssueStatus.Resolved
            };

            @params.IssueTypes.Add(IssueType.GeneralQuestion);
            @params.IssueTypes.Add(IssueType.TranslationMistake);

            Assert.Equal(expectedQueryString, @params.ToQueryParams().ToQueryString());
        }

        [Fact]
        public async Task StringCommentBatchOperations()
        {
            const int projectId = 1;

            var patches = new[]
            {
                new StringCommentBatchOpPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = new StringCommentBatchOpPatchPath(
                        commentId: 2814,
                        pathCode: StringCommentBatchOpPatchPath.Code.Text),
                    Value = "some issue edited"
                },
                new StringCommentBatchOpPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = new StringCommentBatchOpPatchPath(
                        commentId: 2814,
                        pathCode: StringCommentBatchOpPatchPath.Code.IssueStatus),
                    Value = IssueStatus.Resolved
                },
                new StringCommentBatchOpPatch
                {
                    Operation = PatchOperation.Add,
                    Path = StringCommentBatchOpPatchPath.Empty,
                    Value = new
                    {
                        text = "some issue",
                        stringId = 1,
                        type = "issue",
                        targetLanguageId = "en",
                        isShared = true,
                        issueType = IssueType.TranslationMistake
                    }
                },
                new StringCommentBatchOpPatch
                {
                    Operation = PatchOperation.Remove,
                    Path = new StringCommentBatchOpPatchPath(commentId: 2815)
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(patches, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Resources.StringComments.BatchOperations_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/comments";

            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.StringComments.BatchOperations_Response)
                });
            
            var executor = new StringCommentsApiExecutor(mockClient.Object);
            ResponseList<StringComment> response = await executor.StringCommentBatchOperations(projectId, patches);
            
            Assert.NotNull(response.Data.FirstOrDefault());
        }
        
        [Fact]
        public async Task DeleteCommentAttachment()
        {
            const int projectId = 1;
            const long stringCommentId = 2814;
            const long attachmentId = 5678;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/comments/{stringCommentId}/attachments/{attachmentId}";

            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new StringCommentsApiExecutor(mockClient.Object);
    
            await executor.DeleteCommentAttachment(projectId, stringCommentId, attachmentId);

            mockClient.Verify(client => client.SendDeleteRequest(url, null), Times.Once);
        }
    }
}