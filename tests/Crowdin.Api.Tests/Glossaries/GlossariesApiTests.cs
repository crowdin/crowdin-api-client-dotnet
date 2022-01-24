
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.Glossaries;
using Crowdin.Api.Tests.Core;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.Tests.Glossaries
{
    public class GlossariesApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();
        
        [Fact]
        public async Task ListGlossaries()
        {
            const int groupId = 2;

            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            queryParams.Add("groupId", groupId.ToString());

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendGetRequest("/glossaries", queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Glossaries.ListGlossaries_Response)
                });

            var executor = new GlossariesApiExecutor(mockClient.Object);
            ResponseList<Glossary> response = await executor.ListGlossaries(groupId: groupId);
            
            Assert.NotNull(response);
            Assert.Single(response.Data);
            Assert.Equal(groupId, response.Data[0].GroupId);
        }

        [Fact]
        public async Task EditGlossary()
        {
            const int glossaryId = 2;
            const string newName = "Be My Eyes iOS's Glossary";
            const string newLanguageId = "fr";

            var patches = new[]
            {
                new GlossaryPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = GlossaryPatchPath.Name,
                    Value = newName
                },
                new GlossaryPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = GlossaryPatchPath.LanguageId,
                    Value = newLanguageId
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(patches, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.Glossaries.EditGlossary_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            var url = $"/glossaries/{glossaryId}";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Glossaries.EditGlossary_Response)
                });

            var executor = new GlossariesApiExecutor(mockClient.Object);
            Glossary response = await executor.EditGlossary(glossaryId, patches);
            
            Assert.NotNull(response);
            Assert.Equal(newName, response.Name);
            Assert.Equal(newLanguageId, response.LanguageId);
        }
    }
}