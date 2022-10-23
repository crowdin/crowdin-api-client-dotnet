
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

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
        private const int projectId = 1;
        private const int reportSettingsTemplateId = 2;

        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task ListReportSettingsTemplate()
        {
            var mockResponseObject = JObject.Parse(@"
                {
                      ""data"": [
                        {
                          ""data"": {
                            ""id"": 1,
                            ""name"": ""Default template"",
                            ""currency"": ""USD"",
                            ""unit"": ""words"",
                            ""mode"": ""simple"",
                            ""config"": {
                              ""regularRates"": [
                                {
                                  ""mode"": ""tm_match"",
                                  ""value"": 0.1
                                }
                              ],
                              ""individualRates"": [
                                {
                                  ""languageIds"": [
                                    ""uk""
                                  ],
                                  ""userIds"": [
                                    1
                                  ],
                                  ""rates"": [
                                    {
                                      ""mode"": ""tm_match"",
                                      ""value"": 0.1
                                    }
                                  ]
                                }
                              ]
                            },
                            ""createdAt"": ""2019-09-23T11:26:54+00:00"",
                            ""updatedAt"": ""2019-09-23T11:26:54+00:00""
                          }
                        }
                      ],
                      ""pagination"": {
                        ""offset"": 0,
                        ""limit"": 25
                      }
                    }"
            );

            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/reports/settings-templates";

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = mockResponseObject
                });

            var executor = new ReportsApiExecutor(mockClient.Object);
            var response = await executor.ListReportSettingsTemplates(projectId);

            Assert.NotNull(response);
            Assert.IsType<ResponseList<ReportSettingsTemplateBase>>(response);
        }

        [Fact]
        public async Task AddReportSettingsTemplate_Simple()
        {
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
            var response = (ReportSettingsTemplateSimple)await executor.AddReportSettingsTemplate(projectId, request);

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
            var response = (ReportSettingsTemplateFuzzy)await executor.AddReportSettingsTemplate(projectId, request);

            Assert.Equal(ReportSettingsTemplateMode.Fuzzy, response.Mode);
            Assert.Equal(ReportCurrency.USD, response.Currency);
            Assert.Equal(DateTimeOffset.Parse("2019-09-23T11:26:54+00:00"), response.CreatedAt);

            Assert.Single(response.Config.RegularRates);
            Assert.Equal(ReportSettingsFuzzyConfig.RateMode.Option_94_90, response.Config.RegularRates.First().Mode);
            Assert.Equal(0.1f, response.Config.RegularRates.First().Value);
        }

        [Fact]
        public async Task GetReportSettingsTemplate()
        {
            var mockResponseObject = JObject.Parse(@"
                {
                   
                      ""data"": {
                        ""id"": 1,
                        ""name"": ""Default template"",
                        ""currency"": ""USD"",
                        ""unit"": ""words"",
                        ""mode"": ""simple"",
                        ""config"": {
                          ""regularRates"": [
                            {
                              ""mode"": ""tm_match"",
                              ""value"": 0.1
                            }
                          ],
                          ""individualRates"": [
                            {
                              ""languageIds"": [
                                ""uk""
                              ],
                              ""userIds"": [
                                1
                              ],
                              ""rates"": [
                                {
                                  ""mode"": ""tm_match"",
                                  ""value"": 0.1
                                }
                              ]
                            }
                          ]
                        },
                        ""createdAt"": ""2019-09-23T11:26:54+00:00"",
                        ""updatedAt"": ""2019-09-23T11:26:54+00:00""
                    }
                }");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/reports/settings-templates/{reportSettingsTemplateId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = mockResponseObject
                });

            var executor = new ReportsApiExecutor(mockClient.Object);
            var response = await executor.GetReportSettingsTemplate(projectId, reportSettingsTemplateId);

            Assert.NotNull(response);
        }

        [Fact]
        public void EditReportSettingsTemplate_RequestSerializationAsync()
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

        [Fact]
        public async Task DeleteReportSettingsTemplate()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/settings-templates/{reportSettingsTemplateId}";

            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new ReportsApiExecutor(mockClient.Object);

            try
            {
                await executor.DeleteReportSettingsTemplate(projectId, reportSettingsTemplateId);
            }
            catch (CrowdinApiException e)
            {
                Assert.True(true, e.Message);
                return;
            }

            Assert.True(false);
        }

        [Fact]
        public async Task DeleteReportSettingsTemplate_Throw()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/settings-templates/{reportSettingsTemplateId}";

            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.Unauthorized);

            var executor = new ReportsApiExecutor(mockClient.Object);

            await Assert.ThrowsAsync<CrowdinApiException>(async () => await executor.DeleteReportSettingsTemplate(projectId, reportSettingsTemplateId));
        }
    }
}
