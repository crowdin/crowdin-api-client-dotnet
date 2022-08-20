
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.Reports;
using Crowdin.Api.Tests.Core;
using Crowdin.Api.Tests.Core.Resources;

namespace Crowdin.Api.Tests.Reports
{
    public class ReportSettingsTemplatesApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task AddReportSettingsTemplate_Simple()
        {
            const int projectId = 1;

            var request = new AddReportSettingsTemplateSimpleModeRequest
            {
                Name = "Default template",
                Currency = ReportCurrency.USD,
                Unit = ReportUnit.Words,
                Config = new ReportSettingsSimpleConfig
                {
                    RegularRates = new[]
                    {
                        new ReportSettingsSimpleConfig.RegularRate
                        {
                            Mode = ReportSettingsSimpleConfig.RateMode.TmMatch,
                            Value = 0.1f
                        }
                    },
                    IndividualRates = new[]
                    {
                        new ReportSettingsSimpleConfig.IndividualRate
                        {
                            LanguageIds = new[]
                            {
                                "uk"
                            },
                            UserIds = new[]
                            {
                                1
                            },
                            Rates = new[]
                            {
                                new ReportSettingsSimpleConfig.RegularRate
                                {
                                    Mode = ReportSettingsSimpleConfig.RateMode.TmMatch,
                                    Value = 0.1f
                                }
                            }
                        }
                    }
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Reports_SettingsTemplates.AddReportSettingsTemplate_Simple_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/reports/settings-templates";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Reports_SettingsTemplates.AddReportSettingsTemplate_Simple_Response)
                });

            var executor = new ReportsApiExecutor(mockClient.Object);
            var response = (ReportSettingsTemplateSimple) await executor.AddReportSettingsTemplate(projectId, request);

            Assert.Equal(ReportSettingsTemplateMode.Simple, response.Mode);
            Assert.Equal(ReportCurrency.USD, response.Currency);
            Assert.Equal(DateTimeOffset.Parse("2019-09-23T11:26:54+00:00"), response.CreatedAt);

            Assert.Single(response.Config.RegularRates);
            Assert.Equal(ReportSettingsSimpleConfig.RateMode.TmMatch, response.Config.RegularRates[0].Mode);
            Assert.Equal(0.1f, response.Config.RegularRates[0].Value);
        }

        [Fact]
        public async Task AddReportSettingsTemplate_Fuzzy()
        {
            const int projectId = 1;

            var request = new AddReportSettingsTemplateFuzzyModeRequest
            {
                Name = "Default template",
                Currency = ReportCurrency.USD,
                Unit = ReportUnit.Words,
                Config = new ReportSettingsFuzzyConfig
                {
                    RegularRates = new[]
                    {
                        new ReportSettingsFuzzyConfig.RegularRate
                        {
                            Mode = ReportSettingsFuzzyConfig.RateMode.Option_94_90,
                            Value = 0.1f
                        }
                    },
                    IndividualRates = new[]
                    {
                        new ReportSettingsFuzzyConfig.IndividualRate
                        {
                            LanguageIds = new[]
                            {
                                "uk"
                            },
                            UserIds = new[]
                            {
                                1
                            },
                            Rates = new[]
                            {
                                new ReportSettingsFuzzyConfig.RegularRate
                                {
                                    Mode = ReportSettingsFuzzyConfig.RateMode.Option_94_90,
                                    Value = 0.1f
                                }
                            }
                        }
                    }
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Reports_SettingsTemplates.AddReportSettingsTemplate_Fuzzy_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/reports/settings-templates";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Reports_SettingsTemplates.AddReportSettingsTemplate_Fuzzy_Response)
                });

            var executor = new ReportsApiExecutor(mockClient.Object);
            var response = (ReportSettingsTemplateFuzzy) await executor.AddReportSettingsTemplate(projectId, request);

            Assert.Equal(ReportSettingsTemplateMode.Fuzzy, response.Mode);
            Assert.Equal(ReportCurrency.USD, response.Currency);
            Assert.Equal(DateTimeOffset.Parse("2019-09-23T11:26:54+00:00"), response.CreatedAt);

            Assert.Single(response.Config.RegularRates);
            Assert.Equal(ReportSettingsFuzzyConfig.RateMode.Option_94_90, response.Config.RegularRates.First().Mode);
            Assert.Equal(0.1f, response.Config.RegularRates.First().Value);
        }

        [Fact]
        public void EditReportSettingsTemplate_RequestSerialization()
        {
            var patches = new[]
            {
                new ReportSettingsTemplatePatch
                {
                    Operation = PatchOperation.Replace,
                    Path = ReportSettingsTemplatePatchPath.Currency,
                    Value = ReportCurrency.AUD
                },
                new ReportSettingsTemplatePatch
                {
                    Operation = PatchOperation.Replace,
                    Path = ReportSettingsTemplatePatchPath.Mode,
                    Value = ReportSettingsTemplateMode.Fuzzy
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(patches, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Reports_SettingsTemplates.EditReportSettingsTemplate_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
        }
    }
}
