
using System.Net;
using System.Threading.Tasks;
using Crowdin.Api.Core;
using Crowdin.Api.StringTranslations;
using Crowdin.Api.UnitTesting.Resources;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.UnitTesting.Tests.StringTranslations
{
    public class VotesApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task AddVote()
        {
            const int projectId = 1;

            var request = new AddVoteRequest
            {
                Mark = TranslationVoteMark.Up,
                TranslationId = 653412
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(StringTranslations_Votes.AddVote_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/votes";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(StringTranslations_Votes.AddVote_Response)
                });

            var executor = new StringTranslationsApiExecutor(mockClient.Object);
            TranslationVote response = await executor.AddVote(projectId, request);

            Assert.NotNull(response);
            Assert.Equal(19069345, response.TranslationId);
            Assert.Equal(TranslationVoteMark.Up, response.Mark);
            Assert.Equal(19, response.User.Id);
        }

        [Fact]
        public async Task CancelVote_Success()
        {
            const int projectId = 1;
            const int voteId = 2;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/votes/{voteId}";

            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new StringTranslationsApiExecutor(mockClient.Object);
            await executor.CancelVote(projectId, voteId);
        }

        [Fact]
        public async Task CancelVote_ExceptionThrown()
        {
            const int projectId = 1;
            const int voteId = 2;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/votes/{voteId}";

            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.Unauthorized);

            var executor = new StringTranslationsApiExecutor(mockClient.Object);
            await Assert.ThrowsAsync<CrowdinApiException>(() => executor.CancelVote(projectId, voteId));
        }
    }
}