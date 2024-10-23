
using System;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.ProjectsGroups;
using Crowdin.Api.SourceFiles;
using Crowdin.Api.UnitTesting.Resources;

namespace Crowdin.Api.UnitTesting.Tests.ProjectsGroups
{
    public class ProjectFileFormatSettingsApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task DownloadProjectFileFormatSettingsCustomSegmentation()
        {
            const int projectId = 1;
            const int fileFormatSettingsId = 2;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/file-format-settings/{fileFormatSettingsId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Projects_FileFormatSettings.DownloadProjectFileFormatSettingsCustomSegmentation_Response)
                });

            var executor = new ProjectsGroupsApiExecutor(mockClient.Object);
            DownloadLink response = await executor.DownloadProjectFileFormatSettingsCustomSegmentation(projectId, fileFormatSettingsId);

            Assert.NotNull(response);
            Assert.Equal(DateTimeOffset.Parse("2019-09-20T10:31:21+00:00"), response.ExpireIn);
        }

        [Fact]
        public async Task AddProjectFileFormatSettings_Properties()
        {
            const int projectId = 1;

            var request = new AddProjectFileFormatSettingsRequest
            {
                Format = ProjectFileType.Properties,
                Settings = new PropertyFileFormatSettings
                {
                    EscapeQuotes = EscapeQuotesMode.EscapeSingleQuoteByAnotherSingleQuote,
                    EscapeSpecialCharacters = EscapeSpecialCharsMode.EscapeByBackSlash,
                    ExportPattern = "string"
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(
                Projects_FileFormatSettings.AddProjectFileFormatSettings_Request,
                JsonSettings);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/file-format-settings";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Projects_FileFormatSettings.AddProjectFileFormatSettings_Response)
                });

            var executor = new ProjectsGroupsApiExecutor(mockClient.Object);
            FileFormatSettingsResource response = await executor.AddProjectFileFormatSettings(projectId, request);

            Assert.NotNull(response);
            Assert.Equal(ProjectFileType.Properties, response.Format);

            Assert.NotNull(response.Settings);
            Assert.IsType<PropertyFileFormatSettings>(response.Settings);

            var settings = (PropertyFileFormatSettings)response.Settings;
            Assert.Equal(EscapeQuotesMode.EscapeSingleQuoteByAnotherSingleQuote, settings.EscapeQuotes);
        }

        [Fact]
        public async Task EditProjectFileFormatSettings_Properties()
        {
            const int projectId = 1;
            const int fileFormatSettingsId = 44;

            var request = new[]
            {
                new ProjectFileFormatSettingsPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = ProjectFileFormatSettingsPatchPath.Format,
                    Value = ProjectFileType.Properties
                },
                new ProjectFileFormatSettingsPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = ProjectFileFormatSettingsPatchPath.Settings,
                    Value = new PropertyFileFormatSettings
                    {
                        EscapeQuotes = EscapeQuotesMode.EscapeSingleQuoteByAnotherSingleQuote,
                        EscapeSpecialCharacters = EscapeSpecialCharsMode.EscapeByBackSlash
                    }
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Projects_FileFormatSettings.EditProjectFileFormatSettings_Request, JsonSettings);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/file-format-settings/{fileFormatSettingsId}";

            mockClient
                .Setup(client => client.SendPatchRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Projects_FileFormatSettings.EditProjectFileFormatSettings_Response)
                });

            var executor = new ProjectsGroupsApiExecutor(mockClient.Object);
            FileFormatSettingsResource response = await executor.EditProjectFileFormatSettings(projectId, fileFormatSettingsId, request);

            Assert.NotNull(response);
            Assert.Equal(ProjectFileType.Properties, response.Format);

            Assert.NotNull(response.Settings);
            Assert.IsType<PropertyFileFormatSettings>(response.Settings);

            var settings = (PropertyFileFormatSettings)response.Settings;
            Assert.Equal(EscapeQuotesMode.EscapeSingleQuoteByAnotherSingleQuote, settings.EscapeQuotes);
            Assert.Equal(EscapeSpecialCharsMode.EscapeByBackSlash, settings.EscapeSpecialCharacters);
        }
    }
}