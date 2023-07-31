
using System;

using Newtonsoft.Json;
using Xunit;

using Crowdin.Api.Reports;
using Crowdin.Api.Tests.Core;

namespace Crowdin.Api.Tests.Reports
{
    public class ReportSerializationTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();
        
        [Fact]
        public void CostEstimationPostEditing_GeneralSchema()
        {
            var request = new CostEstimationPostEditingGenerateReportRequest
            {
                Schema = new CostEstimationPostEditingGenerateReportRequest.GeneralSchema
                {
                    Unit = ReportUnit.CharsWithSpaces,
                    Currency = ReportCurrency.EUR,
                    Format = ReportFormat.Json,
                    BaseRates = new CostEstimationPostEditingGenerateReportRequest.BaseRatesForm
                    {
                        FullTranslation = 0.1f,
                        Proofread = 0.12f
                    },
                    IndividualRates = new[]
                    {
                        new CostEstimationPostEditingGenerateReportRequest.IndividualRate
                        {
                            LanguageIds = new[] { "uk", "es" },
                            UserIds = new[] { 1, 2, 3 },
                            FullTranslation = 0.1f,
                            Proofread = 0.12f
                        }
                    },
                    NetRateSchemes = new CostEstimationPostEditingGenerateReportRequest.NetRateSchemes
                    {
                        TmMatch = new[]
                        {
                            new CostEstimationPostEditingGenerateReportRequest.Match
                            {
                                MatchType = CostEstimationPostEditingGenerateReportRequest.MatchType.Option_100,
                                Price = 0.1f
                            }
                        }
                    },
                    CalculateInternalMatches = false,
                    IncludePreTranslatedStrings = true,
                    LanguageId = "ach",
                    FileIds = new[] { 138 },
                    DirectoryIds = new[] { 11 },
                    BranchIds = new[] { 18 },
                    LabelIds = new[] { 13 },
                    LabelIncludeType = ReportLabelIncludeType.StringsWithLabel
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(
                Core.Resources.Reports.CostEstimationPostEditing_GeneralSchema_Request);
            
            Assert.Equal(expectedRequestJson, actualRequestJson);
        }

        [Fact]
        public void CostEstimationPostEditing_ByTaskSchema()
        {
            var request = new CostEstimationPostEditingGenerateReportRequest
            {
                Schema = new CostEstimationPostEditingGenerateReportRequest.ByTaskSchema
                {
                    BaseRates = new CostEstimationPostEditingGenerateReportRequest.BaseRatesForm
                    {
                        FullTranslation = 0.1f,
                        Proofread = 0.12f
                    },
                    IndividualRates = new[]
                    {
                        new CostEstimationPostEditingGenerateReportRequest.IndividualRate
                        {
                            LanguageIds = new[] { "uk", "es" },
                            UserIds = new[] { 1, 2, 3 },
                            FullTranslation = 0.1f,
                            Proofread = 0.12f
                        }
                    },
                    NetRateSchemes = new CostEstimationPostEditingGenerateReportRequest.NetRateSchemes
                    {
                        TmMatch = new[]
                        {
                            new CostEstimationPostEditingGenerateReportRequest.Match
                            {
                                MatchType = CostEstimationPostEditingGenerateReportRequest.MatchType.Option_100,
                                Price = 0.1f
                            }
                        }
                    },
                    TaskId = 1
                }
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(
                Core.Resources.Reports.CostEstimationPostEditing_ByTaskSchema_Request);
            
            Assert.Equal(expectedRequestJson, actualRequestJson);
        }

        [Fact]
        public void TranslationCostsPostEditing_GeneralSchema()
        {
            var request = new TranslationCostsPostEditingGenerateReportRequest
            {
                Schema = new TranslationCostsPostEditingGenerateReportRequest.GeneralSchema
                {
                    Unit = ReportUnit.Words,
                    Currency = ReportCurrency.USD,
                    Format = ReportFormat.Xlsx,
                    BaseRates = new TranslationCostsPostEditingGenerateReportRequest.BaseRatesForm
                    {
                        FullTranslation = 0.1f,
                        Proofread = 0.12f
                    },
                    IndividualRates = new[]
                    {
                        new TranslationCostsPostEditingGenerateReportRequest.IndividualRate
                        {
                            LanguageIds = new[] { "uk" },
                            UserIds = new[] { 1 },
                            FullTranslation = 0.1f,
                            Proofread = 0.12f
                        }
                    },
                    NetRateSchemes = new TranslationCostsPostEditingGenerateReportRequest.NetRateSchemes
                    {
                        TmMatch = new[]
                        {
                            new TranslationCostsPostEditingGenerateReportRequest.Match
                            {
                                MatchType = TranslationCostsPostEditingGenerateReportRequest.MatchType.Perfect,
                                Price = 0.1f
                            }
                        },
                        MtMatch = new[]
                        {
                            new TranslationCostsPostEditingGenerateReportRequest.Match
                            {
                                MatchType = TranslationCostsPostEditingGenerateReportRequest.MatchType.Option_99_82,
                                Price = 0.1f
                            }
                        },
                        SuggestionMatch = new[]
                        {
                            new TranslationCostsPostEditingGenerateReportRequest.Match
                            {
                                MatchType = TranslationCostsPostEditingGenerateReportRequest.MatchType.Option_81_60,
                                Price = 0.1f
                            }
                        }
                    },
                    GroupBy = TranslationCostsPostEditingGenerateReportRequest.GeneralSchema.GroupingParameter.User,
                    LanguageId = "ach",
                    UserIds = new[] { 13 },
                    FileIds = new[] { 138 },
                    DirectoryIds = new[] { 11 },
                    BranchIds = new[] { 18 }
                }
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(
                Core.Resources.Reports.TranslationCostsPostEditing_GeneralSchema_Request);
            
            Assert.Equal(expectedRequestJson, actualRequestJson);
        }

        [Fact]
        public void TranslationCostsPostEditing_ByTaskSchema()
        {
            var request = new TranslationCostsPostEditingGenerateReportRequest
            {
                Schema = new TranslationCostsPostEditingGenerateReportRequest.ByTaskSchema
                {
                    Unit = ReportUnit.Words,
                    Currency = ReportCurrency.USD,
                    Format = ReportFormat.Xlsx,
                    BaseRates = new TranslationCostsPostEditingGenerateReportRequest.BaseRatesForm
                    {
                        FullTranslation = 0.1f,
                        Proofread = 0.12f
                    },
                    IndividualRates = new[]
                    {
                        new TranslationCostsPostEditingGenerateReportRequest.IndividualRate
                        {
                            LanguageIds = new[] { "uk" },
                            UserIds = new[] { 1 },
                            FullTranslation = 0.1f,
                            Proofread = 0.12f
                        }
                    },
                    NetRateSchemes = new TranslationCostsPostEditingGenerateReportRequest.NetRateSchemes
                    {
                        TmMatch = new[]
                        {
                            new TranslationCostsPostEditingGenerateReportRequest.Match
                            {
                                MatchType = TranslationCostsPostEditingGenerateReportRequest.MatchType.Perfect,
                                Price = 0.1f
                            }
                        },
                        MtMatch = new[]
                        {
                            new TranslationCostsPostEditingGenerateReportRequest.Match
                            {
                                MatchType = TranslationCostsPostEditingGenerateReportRequest.MatchType.Option_99_82,
                                Price = 0.1f
                            }
                        },
                        SuggestionMatch = new[]
                        {
                            new TranslationCostsPostEditingGenerateReportRequest.Match
                            {
                                MatchType = TranslationCostsPostEditingGenerateReportRequest.MatchType.Option_81_60,
                                Price = 0.1f
                            }
                        }
                    },
                    TaskId = 1
                }
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(
                Core.Resources.Reports.TranslationCostsPostEditing_ByTaskSchema_Request);
            
            Assert.Equal(expectedRequestJson, actualRequestJson);
        }

        [Fact]
        public void Group_TranslationCostsPostEditing_GeneralSchema()
        {
            var request = new GroupTranslationCostsPostEditingGenerateGroupReportRequest
            {
                Schema = new GroupTranslationCostsPostEditingGenerateGroupReportRequest.GeneralSchema
                {
                    ProjectIds = new[] { 13 },
                    Unit = ReportUnit.Words,
                    Currency = ReportCurrency.USD,
                    Format = ReportFormat.Xlsx,
                    BaseRates = new GroupTranslationCostsPostEditingGenerateGroupReportRequest.BaseRatesForm
                    {
                        FullTranslation = 0.1f,
                        Proofread = 0.12f
                    },
                    IndividualRates = new[]
                    {
                        new GroupTranslationCostsPostEditingGenerateGroupReportRequest.IndividualRate
                        {
                            LanguageIds = new[] { "uk" },
                            UserIds = new[] { 1 },
                            FullTranslation = 0.1f,
                            Proofread = 0.12f
                        }
                    },
                    NetRateSchemes = new GroupTranslationCostsPostEditingGenerateGroupReportRequest.NetRateSchemes
                    {
                        TmMatch = new[]
                        {
                            new GroupTranslationCostsPostEditingGenerateGroupReportRequest.Match
                            {
                                MatchType = GroupTranslationCostsPostEditingGenerateGroupReportRequest.MatchType.Perfect,
                                Price = 0.1f
                            }
                        },
                        MtMatch = new[]
                        {
                            new GroupTranslationCostsPostEditingGenerateGroupReportRequest.Match
                            {
                                MatchType = GroupTranslationCostsPostEditingGenerateGroupReportRequest.MatchType.Option_99_82,
                                Price = 0.1f
                            }
                        },
                        SuggestionMatch = new[]
                        {
                            new GroupTranslationCostsPostEditingGenerateGroupReportRequest.Match
                            {
                                MatchType = GroupTranslationCostsPostEditingGenerateGroupReportRequest.MatchType.Option_81_60,
                                Price = 0.1f
                            }
                        }
                    },
                    GroupBy = GroupTranslationCostsPostEditingGenerateGroupReportRequest.GeneralSchema.GroupingParameter.Language,
                    UserIds = new[] { 13 }
                }
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(
                Core.Resources.Reports.Group_TranslationCostsPostEditing_GeneralSchema_Request);
            
            Assert.Equal(expectedRequestJson, actualRequestJson);
        }
    }
}