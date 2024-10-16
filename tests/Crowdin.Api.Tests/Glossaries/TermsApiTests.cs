
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.Glossaries;
using Crowdin.Api.Tests.Testing;
using Crowdin.Api.Tests.Testing.Resources;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.Tests.Glossaries
{
    public class TermsApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();
        
        [Fact]
        public async Task AddTerm()
        {
            const int glossaryId = 1;

            var request = new AddTermRequest
            {
                LanguageId = "fr",
                Text = "voir",
                Description = "use for pages only (check screenshots)",
                PartOfSpeech = PartOfSpeech.SubordinatingConjunction
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Glossaries_Terms.AddTerm_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            var url = $"/glossaries/{glossaryId}/terms";
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Glossaries_Terms.AddTerm_Response)
                });

            var executor = new GlossariesApiExecutor(mockClient.Object);
            Term response = await executor.AddTerm(glossaryId, request);
            
            Assert.NotNull(response);
            Assert.Equal(request.Text, response.Text);
            Assert.Equal(request.Description, response.Description);
            Assert.Equal(request.PartOfSpeech, response.PartOfSpeech);
        }

        [Fact]
        public async Task EditTerm()
        {
            const int glossaryId = 6;
            const int termId = 2;
            const PartOfSpeech newPartOfSpeech = PartOfSpeech.SubordinatingConjunction;

            var patches = new[]
            {
                new TermPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = TermPatchPath.Text,
                    Value = "Voir"
                },
                new TermPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = TermPatchPath.Description,
                    Value = "use for pages only (check screenshots)"
                },
                new TermPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = TermPatchPath.PartOfSpeech,
                    Value = newPartOfSpeech
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(patches, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Glossaries_Terms.EditTerm_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            var url = $"/glossaries/{glossaryId}/terms/{termId}";
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Glossaries_Terms.EditTerm_Response)
                });

            var executor = new GlossariesApiExecutor(mockClient.Object);
            Term response = await executor.EditTerm(glossaryId, termId, patches);
            
            Assert.NotNull(response);
            Assert.Equal(glossaryId, response.GlossaryId);
            Assert.Equal(newPartOfSpeech, response.PartOfSpeech);
        }
    }
}