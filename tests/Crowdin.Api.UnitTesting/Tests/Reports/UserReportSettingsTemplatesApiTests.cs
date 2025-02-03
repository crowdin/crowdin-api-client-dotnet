
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
using Crowdin.Api.Reports;
using Crowdin.Api.UnitTesting.Resources;

using Match = Crowdin.Api.Reports.Match;

// ReSharper disable ConditionalAccessQualifierIsNonNullableAccordingToAPIContract

namespace Crowdin.Api.UnitTesting.Tests.Reports
{
    public class UserReportSettingsTemplatesApiTests
    {
        private const int UserId = 1;
        private const int ReportSettingsTemplateId = 2;
        
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();
        
        [Fact]
        public async Task ListUserReportSettingsTemplates()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{UserId}/reports/settings-templates";

            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Reports_UserSettingsTemplates.CommonResponses_List)
                });
            
            var executor = new ReportsApiExecutor(mockClient.Object);
            
            ResponseList<UserReportSettingsTemplate> response =
                await executor.ListUserReportSettingsTemplates(UserId);
            
            Assert_UserReportSettingsTemplate(response?.Data?.FirstOrDefault());
        }

        [Fact]
        public async Task AddUserReportSettingsTemplate()
        {
            var request = new AddUserReportSettingsTemplateRequest
            {
                Name = "Default template",
                Currency = ReportCurrency.USD,
                Unit = ReportUnit.Words,
                Config = new AddUserReportSettingsTemplateRequest.ConfigurationForm
                {
                    BaseRates = new BaseRatesForm
                    {
                        FullTranslation = 0.1f,
                        Proofread = 0.12f
                    },
                    IndividualRates =
                    [
                        new AddUserReportSettingsTemplateRequest.ConfigurationForm.IndividualRateForm
                        {
                            LanguageIds = [ "uk" ],
                            FullTranslation = 0.1f,
                            Proofread = 0.12f
                        }
                    ],
                    NetRateSchemes = new AddUserReportSettingsTemplateRequest.ConfigurationForm.NetRateSchemesForm
                    {
                        TmMatch =
                        [
                            new Match
                            {
                                MatchType = MatchType.Perfect,
                                Price = 0.1f
                            }
                        ],
                        MtMatch = 
                        [
                            new Match
                            {
                                MatchType = MatchType.Option_100,
                                Price = 0.1f
                            }
                        ],
                        AiMatch = 
                        [
                            new Match
                            {
                                MatchType = MatchTypeObject.FromStaticRange(MatchType.Option_99_82),
                                Price = 0.1f
                            }
                        ],
                        SuggestionMatch = 
                        [
                            new Match
                            {
                                MatchType = MatchTypeObject.FromCustomRange(70, 80),
                                Price = 0.1f
                            }
                        ]
                    }
                }
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Reports_UserSettingsTemplates.AddUserReportSettingsTemplate_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/users/{UserId}/reports/settings-templates";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Reports_UserSettingsTemplates.CommonResponses_Single)
                });
            
            var executor = new ReportsApiExecutor(mockClient.Object);
            UserReportSettingsTemplate response = await executor.AddUserReportSettingsTemplate(UserId, request);
            
            Assert_UserReportSettingsTemplate(response);
        }

        [Fact]
        public async Task GetUserReportSettingsTemplate()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/users/{UserId}/reports/settings-templates/{ReportSettingsTemplateId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Reports_UserSettingsTemplates.CommonResponses_Single)
                });
            
            var executor = new ReportsApiExecutor(mockClient.Object);
            UserReportSettingsTemplate response =
                await executor.GetUserReportSettingsTemplate(UserId, ReportSettingsTemplateId);
            
            Assert_UserReportSettingsTemplate(response);
        }

        [Fact]
        public async Task DeleteUserReportSettingsTemplate()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/users/{UserId}/reports/settings-templates/{ReportSettingsTemplateId}";
            
            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);
            
            var executor = new ReportsApiExecutor(mockClient.Object);
            await executor.DeleteUserReportSettingsTemplate(UserId, ReportSettingsTemplateId);
        }

        [Fact]
        public async Task EditUserReportSettingsTemplate()
        {
            var request = new[]
            {
                new UserReportSettingsTemplatePatch
                {
                    Operation = PatchOperation.Replace,
                    Path = UserReportSettingsTemplatePatchPath.Unit,
                    Value = ReportUnit.Chars
                },
                new UserReportSettingsTemplatePatch
                {
                    Operation = PatchOperation.Replace,
                    Path = UserReportSettingsTemplatePatchPath.Name,
                    Value = "Changed name"
                }
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson =
                TestUtils.CompactJson(Reports_UserSettingsTemplates.EditUserReportSettingsTemplate_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/users/{UserId}/reports/settings-templates/{ReportSettingsTemplateId}";

            mockClient
                .Setup(client => client.SendPatchRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Reports_UserSettingsTemplates.CommonResponses_Single)
                });
            
            var executor = new ReportsApiExecutor(mockClient.Object);
            UserReportSettingsTemplate response = await executor.EditUserReportSettingsTemplate(
                UserId,
                ReportSettingsTemplateId,
                request);

            Assert_UserReportSettingsTemplate(response);
        }

        private static void Assert_UserReportSettingsTemplate(UserReportSettingsTemplate? template)
        {
            ArgumentNullException.ThrowIfNull(template);
            
            Assert.Equal(1, template.Id);
            Assert.Equal("Default template", template.Name);
            Assert.Equal(ReportCurrency.USD, template.Currency);

            DateTimeOffset date = DateTimeOffset.Parse("2019-09-23T11:26:54+00:00");
            Assert.Equal(date, template.CreatedAt);
            Assert.Equal(date, template.UpdatedAt);

            UserReportSettingsTemplate.Configuration? config = template.Config;
            ArgumentNullException.ThrowIfNull(config);
            
            Assert.Equal(0.1f, config.BaseRates.FullTranslation);
            Assert.Equal(0.12f, config.BaseRates.Proofread);
            Assert.Equal("uk", config.IndividualRates.First().LanguageIds.First());
            Assert.Equal(0.1f, config.IndividualRates.First().FullTranslation);
            Assert.Equal(0.12f, config.IndividualRates.First().Proofread);
            Assert.Equal(MatchType.Perfect, config.NetRateSchemes.TmMatch.First().MatchType);
            Assert.Equal(MatchType.Option_100, config.NetRateSchemes.AiMatch.First().MatchType);
        }
    }
}