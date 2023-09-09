using System.Net;
using System.Threading.Tasks;
using Crowdin.Api.Core;
using Crowdin.Api.ProjectsGroups;
using Crowdin.Api.SourceFiles;
using Crowdin.Api.Tests.Core;
using Crowdin.Api.Tests.Core.Resources;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.Tests.ProjectsGroups
{
    public class ProjectStringsExporterSettingsApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task ListAllProjectStringsExporterSettings()
        {
            const int projectId = 1;

            var url = $"/projects/{projectId}/strings-exporter-settings";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject =
                        JObject.Parse(Projects_StringsExporterSettings.ListProjectStringsExporterSettings_Response)
                });

            var executor = new ProjectsGroupsApiExecutor(mockClient.Object);
            var response = await executor.ListProjectStringsExporterSettings(projectId);

            Assert.NotNull(response);
            Assert.IsType<ResponseList<StringsExporterSettingsResource>>(response);

            var data = response.Data;
            
            Assert.Equal(ProjectFileType.Android, data[0].Format);
            Assert.IsType<AndroidStringsExporterSettings>(data[0].Settings);
            Assert.Equal(true, data[0].Settings.ConvertPlaceHolders);

            Assert.Equal(ProjectFileType.MacOsX, data[1].Format);
            Assert.IsType<MacOsxStringsExporterSettings>(data[1].Settings);
            Assert.Equal(false, data[1].Settings.ConvertPlaceHolders);
        }

        [Fact]
        public async Task AddProjectStringsExporterSettings_Android()
        {
            const int projectId = 1;

            var request = new AddProjectStringsExporterSettingsRequest
            {
                Format = ProjectFileType.Android,
                Settings = new AndroidStringsExporterSettings
                {
                    ConvertPlaceHolders = true
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(
                Projects_StringsExporterSettings.AddProjectStringsExporterSettings_Request,
                JsonSettings);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/strings-exporter-settings";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject =
                        JObject.Parse(Projects_StringsExporterSettings.AddProjectStringsExporterSettings_Response)
                });

            var executor = new ProjectsGroupsApiExecutor(mockClient.Object);
            StringsExporterSettingsResource response =
                await executor.AddProjectStringsExporterSettings(projectId, request);

            Assert.NotNull(response);
            Assert.Equal(ProjectFileType.Android, response.Format);

            Assert.NotNull(response.Settings);
            Assert.IsType<AndroidStringsExporterSettings>(response.Settings);

            var settings = (AndroidStringsExporterSettings)response.Settings;
            Assert.Equal(true, settings.ConvertPlaceHolders);
        }

        [Fact]
        public async Task GetOneProjectStringsExporterSettings()
        {
            const int projectId = 1;
            const int stringsExporterSettingsId = 45;

            var url = $"/projects/{projectId}/strings-exporter-settings/{stringsExporterSettingsId}";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject =
                        JObject.Parse(Projects_StringsExporterSettings.GetProjectStringsExporterSettings_Response)
                });

            var executor = new ProjectsGroupsApiExecutor(mockClient.Object);
            StringsExporterSettingsResource response =
                await executor.GetProjectStringsExporterSettings(projectId, stringsExporterSettingsId);

            Assert.NotNull(response);
            Assert.Equal(ProjectFileType.Android, response.Format);

            Assert.IsType<AndroidStringsExporterSettings>(response.Settings);

            var settings = (AndroidStringsExporterSettings)response.Settings;
            Assert.Equal(true, settings.ConvertPlaceHolders);
        }

        [Fact]
        public async Task DeleteOneProjectSettingsExporterSettings()
        {
            const int projectId = 1;
            const int stringsExporterSettingsId = 46;
            
            var url = $"/projects/{projectId}/strings-exporter-settings/{stringsExporterSettingsId}";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new ProjectsGroupsApiExecutor(mockClient.Object);
            await executor.DeleteProjectStringsExporterSettings(projectId, stringsExporterSettingsId);
        }
        
        [Fact]
        public async Task EditProjectStringsExporterSettings_MacOsx()
        {
            const int projectId = 1;
            const int stringsExporterSettingsId = 44;

            var request = new[]
            {
                new ProjectStringsExporterSettingsPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = ProjectStringsExporterSettingsPatchPath.Format,
                    Value = ProjectFileType.MacOsX
                },
                new ProjectStringsExporterSettingsPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = ProjectStringsExporterSettingsPatchPath.Settings,
                    Value = new MacOsxStringsExporterSettings
                    {
                        ConvertPlaceHolders = false
                    }
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson =
                TestUtils.CompactJson(Projects_StringsExporterSettings.EditProjectStringsExporterSettings_Request,
                    JsonSettings);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/strings-exporter-settings/{stringsExporterSettingsId}";
            mockClient
                .Setup(client => client.SendPatchRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject =
                        JObject.Parse(Projects_StringsExporterSettings.EditProjectStringsExporterSettings_Response)
                });

            var executor = new ProjectsGroupsApiExecutor(mockClient.Object);
            StringsExporterSettingsResource response =
                await executor.EditProjectStringsExporterSettings(projectId, stringsExporterSettingsId, request);

            Assert.NotNull(response);
            Assert.Equal(ProjectFileType.MacOsX, response.Format);

            Assert.NotNull(response.Settings);
            Assert.IsType<MacOsxStringsExporterSettings>(response.Settings);
            
            var settings = (MacOsxStringsExporterSettings) response.Settings;
            Assert.Equal(false, settings.ConvertPlaceHolders);
        }
    }
}