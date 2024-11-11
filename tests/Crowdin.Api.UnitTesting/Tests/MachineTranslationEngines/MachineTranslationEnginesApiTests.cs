
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
using Crowdin.Api.MachineTranslationEngines;

namespace Crowdin.Api.UnitTesting.Tests.MachineTranslationEngines
{
    public class MachineTranslationEnginesApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task ListMts_IntCredentialsKey()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            mockClient
                .Setup(client => client.SendGetRequest("/mts", queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.MachineTranslationEngines.ListMts_Request_IntCredentialsKey)
                });

            var executor = new MachineTranslationEnginesApiExecutor(mockClient.Object);
            ResponseList<MtEngine>? response = await executor.ListMts();

            MtEngine? mt = response?.Data?.FirstOrDefault();
            ArgumentNullException.ThrowIfNull(mt);

            Assert.Equal((long)1, mt.Credentials["crowdin_nmt"]);
            Assert.Equal((long)2, mt.Credentials["crowdin_nmt_multi_translations"]);

            Assert.Equal(7, mt.SupportedLanguageIds.Length);
        }

        [Fact]
        public async Task ListMts_StringCredentialsKey()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            mockClient
                .Setup(client => client.SendGetRequest("/mts", queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.MachineTranslationEngines.ListMts_Request_StringCredentialsKey)
                });

            var executor = new MachineTranslationEnginesApiExecutor(mockClient.Object);
            ResponseList<MtEngine>? response = await executor.ListMts();

            MtEngine? mt = response?.Data?.FirstOrDefault();
            ArgumentNullException.ThrowIfNull(mt);

            Assert.Equal("stringValue", mt.Credentials["crowdin_nmt"]);
            Assert.Equal("stringValue", mt.Credentials["crowdin_nmt_multi_translations"]);

            Assert.Equal(7, mt.SupportedLanguageIds.Length);
        }

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
            string expectedRequestJson = TestUtils.CompactJson(Resources.MachineTranslationEngines.AddMt_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest("/mts", request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Resources.MachineTranslationEngines.AddMt_Response)
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
            string expectedRequestJson = TestUtils.CompactJson(Resources.MachineTranslationEngines.EditMt_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
        }
    }
}