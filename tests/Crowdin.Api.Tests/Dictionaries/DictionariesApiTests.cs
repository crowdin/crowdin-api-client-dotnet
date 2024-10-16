
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.Dictionaries;
using Crowdin.Api.Tests.Testing;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.Tests.Dictionaries
{
    public class DictionariesApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task ListDictionaries()
        {
            const int projectId = 1;
            const string languageIds = "en";

            var url = $"/projects/{projectId}/dictionaries";
            var queryParams = new Dictionary<string, string>
            {
                { "languageIds", languageIds }
            };
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Testing.Resources.Dictionaries.ListDictionaries)
                });

            var executor = new DictionariesApiExecutor(mockClient.Object);
            ResponseList<Dictionary> response = await executor.ListDictionaries(projectId, languageIds);
            
            Assert.NotNull(response);
            Assert.Single(response.Data);
        }

        [Fact]
        public void EditDictionary_Add_PatchesSerialization()
        {
            var patches = new[]
            {
                new DictionaryPatch
                {
                    Operation = PatchOperation.Add,
                    Path = DictionaryPatchPath.Words,
                    Value = "word 1"
                },
                new DictionaryPatch
                {
                    Operation = PatchOperation.Add,
                    Path = DictionaryPatchPath.Words,
                    Value = "word 2"
                }
            };

            string actualPatchesListJson = JsonConvert.SerializeObject(patches, DefaultSettings);
            string rightPatchesListJson = Testing.Resources.Dictionaries.EditDictionary_OpAdd_RightPatchesListJson;
            
            Assert.NotEmpty(actualPatchesListJson);
            Assert.Equal(rightPatchesListJson, actualPatchesListJson);
        }

        [Fact]
        public void EditDictionary_Remove_PatchesSerialization_SingleIndex()
        {
            var patches = new[]
            {
                new DictionaryPatch
                {
                    Operation = PatchOperation.Remove,
                    Path = new DictionaryPatchPath(new[] { 3 })
                }
            };

            string actualPatchesListJson = JsonConvert.SerializeObject(patches, DefaultSettings);
            string rightPatchesListJson = Testing.Resources.Dictionaries.EditDictionary_OpRemove_RightPatchesListJson_SingleIndex;
            
            Assert.NotEmpty(actualPatchesListJson);
            Assert.Equal(rightPatchesListJson, actualPatchesListJson);
        }
        
        [Fact]
        public void EditDictionary_Remove_PatchesSerialization_MultiIndexesWithDuplicates()
        {
            var patches = new[]
            {
                new DictionaryPatch
                {
                    Operation = PatchOperation.Remove,
                    Path = new DictionaryPatchPath(new []{ 0, 1, 2, 0, 3, 3 })
                },
            };
            
            string actualPatchesListJson = JsonConvert.SerializeObject(patches, DefaultSettings);
            string rightPatchesListJson = Testing.Resources.Dictionaries.EditDictionary_OpRemove_RightPatchesListJson_MultiIndexesWithDuplicates;
            
            Assert.NotEmpty(actualPatchesListJson);
            Assert.Equal(rightPatchesListJson, actualPatchesListJson);
        }
    }
}