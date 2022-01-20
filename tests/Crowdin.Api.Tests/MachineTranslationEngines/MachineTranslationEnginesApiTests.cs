
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.MachineTranslationEngines;
using Crowdin.Api.Tests.Core;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.Tests.MachineTranslationEngines
{
    public class MachineTranslationEnginesApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();
        
        [Fact]
        public async Task AddMt()
        {
            const int groupId = 2;
            
            var request = new AddMtEngineRequest
            {
                Name = "engine name",
                Type = MtEngineType.GoogleAutoML,
                Credentials = new GoogleAutoMLTranslateCredentials
                {
                    Credentials = "auto ml credentials"
                },
                GroupId = groupId
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.MachineTranslationEngines.AddMt_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest("/mts", request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Core.Resources.MachineTranslationEngines.AddMt_Response)
                });

            var executor = new MachineTranslationEnginesApiExecutor(mockClient.Object);
            MtEngine response = await executor.AddMt(request);
            
            Assert.NotNull(response);
            Assert.Equal(groupId, response.GroupId);
        }

        [Fact]
        public void EditMt_RequestSerialization()
        {
            var patches = new[]
            {
                new MtEnginePatch
                {
                    Operation = PatchOperation.Replace,
                    Path = MtEnginePatchPath.Name,
                    Value = "new engine name"
                },
                new MtEnginePatch
                {
                    Operation = PatchOperation.Replace,
                    Path = MtEnginePatchPath.Type,
                    Value = MtEngineType.CustomMT
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(patches, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.MachineTranslationEngines.EditMt_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
        }
    }
}