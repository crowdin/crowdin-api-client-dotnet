using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.Reports;
using Crowdin.Api.UnitTesting.Resources;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.UnitTesting.Tests.Reports
{
    public class OrganizationReportSettingsTemplatesApiTests
    {
        [Fact]
        public async Task ListOrganizationReportSettingsTemplates()
        {
            IDictionary<string, string> queryParams = new Dictionary<string, string>
            {
                ["limit"] = "10",
                ["offset"] = "2",
                ["groupId"] = "12"
            };
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient.Setup(client => client.SendGetRequest("/reports/settings-templates", queryParams))
                .ReturnsAsync(ApiResult("ListOrganizationReportSettingsTemplates"));

            var executor = new ReportsApiExecutor(mockClient.Object);
            ResponseList<ReportSettingsTemplateBase> response = await executor.ListOrganizationReportSettingsTemplates(
                groupId: 12, limit: 10, offset: 2);

            Assert.Single(response.Data);
            Assert.Equal(44, response.Data[0].Id);
            Assert.Equal("Enterprise Quarterly", response.Data[0].Name);
            Assert.Equal(ReportCurrency.USD, response.Data[0].Currency);
            Assert.Equal(ReportSettingsTemplateMode.Simple, response.Data[0].Mode);
            Assert.True(response.Data[0].IsGlobal);
            Assert.Equal(12, response.Data[0].GroupId);
        }

        [Fact]
        public async Task AddOrganizationReportSettingsTemplate()
        {
            var request = new AddReportSettingsTemplateSimpleModeRequest
            {
                Name = "New Quarterly",
                Currency = ReportCurrency.EUR,
                Unit = ReportUnit.Words,
                IsPublic = false,
                GroupId = 12,
                IsGlobal = false,
                Config = new ReportSettingsSimpleConfig
                {
                    RegularRates = new ReportSettingsSimpleConfig.RegularRate[0],
                    IndividualRates = new ReportSettingsSimpleConfig.IndividualRate[0]
                }
            };
            AssertRequest(request, "AddOrganizationReportSettingsTemplate");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient.Setup(client => client.SendPostRequest("/reports/settings-templates", request, null))
                .ReturnsAsync(ApiResult("AddOrganizationReportSettingsTemplate"));

            var executor = new ReportsApiExecutor(mockClient.Object);
            ReportSettingsTemplateBase response = await executor.AddOrganizationReportSettingsTemplate(request);

            Assert.Equal(45, response.Id);
            Assert.Equal("New Quarterly", response.Name);
            Assert.Equal(ReportCurrency.EUR, response.Currency);
            Assert.False(response.IsGlobal);
        }

        [Fact]
        public async Task GetOrganizationReportSettingsTemplate()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient.Setup(client => client.SendGetRequest("/reports/settings-templates/44", null))
                .ReturnsAsync(ApiResult("GetOrganizationReportSettingsTemplate"));

            var executor = new ReportsApiExecutor(mockClient.Object);
            ReportSettingsTemplateBase response = await executor.GetOrganizationReportSettingsTemplate(44);

            Assert.Equal("Enterprise Quarterly", response.Name);
            Assert.Null(response.ProjectId);
            Assert.Equal(12, response.GroupId);
            Assert.True(response.IsGlobal);
        }

        [Fact]
        public async Task EditOrganizationReportSettingsTemplateUsesJsonPointerPath()
        {
            var patches = new[]
            {
                new ReportSettingsTemplatePatch
                {
                    Operation = PatchOperation.Replace,
                    Path = ReportSettingsTemplatePatchPath.Name,
                    Value = "Updated Quarterly"
                }
            };
            AssertRequest(patches, "EditOrganizationReportSettingsTemplate");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient.Setup(client => client.SendPatchRequest("/reports/settings-templates/44", patches, null))
                .ReturnsAsync(ApiResult("EditOrganizationReportSettingsTemplate"));

            var executor = new ReportsApiExecutor(mockClient.Object);
            ReportSettingsTemplateBase response = await executor.EditOrganizationReportSettingsTemplate(44, patches);

            Assert.Equal("Updated Quarterly", response.Name);
            Assert.True(response.IsGlobal);
        }

        [Fact]
        public async Task DeleteOrganizationReportSettingsTemplate()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient.Setup(client => client.SendDeleteRequest("/reports/settings-templates/44", null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new ReportsApiExecutor(mockClient.Object);
            await executor.DeleteOrganizationReportSettingsTemplate(44);

            mockClient.Verify(client => client.SendDeleteRequest("/reports/settings-templates/44", null), Times.Once);
        }

        private static CrowdinApiResult ApiResult(string key)
        {
            return new CrowdinApiResult
            {
                StatusCode = HttpStatusCode.OK,
                JsonObject = (JObject)JObject.Parse(Reports_SettingsTemplates.ApiResponses)[key]!
            };
        }

        private static void AssertRequest(object request, string key)
        {
            JToken expected = JObject.Parse(Reports_SettingsTemplates.ApiRequests)[key]!;
            JToken actual = JToken.Parse(JsonConvert.SerializeObject(request, TestUtils.CreateJsonSerializerOptions()));
            Assert.True(JToken.DeepEquals(expected, actual), $"Request {key} did not match its fixture.");
        }
    }
}
