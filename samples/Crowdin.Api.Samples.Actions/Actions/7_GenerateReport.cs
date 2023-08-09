
using Crowdin.Api.Reports;
using MatchType = Crowdin.Api.Reports.MatchType;

namespace Crowdin.Api.Samples.Actions
{
    public partial class CrowdinActions
    {
        public async Task GenerateReport(int projectId, int directoryId, int fileId)
        {
            // Start report generation task
            ReportStatus reportStatus = await _crowdinApiClient.Reports.GenerateReport(
                projectId,
                new CostEstimationPostEditingGenerateReportRequest
                {
                    Schema = new CostEstimationPostEditingGenerateReportRequest.GeneralSchema
                    {
                        BaseRates = new BaseRatesForm
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
                                new Match
                                {
                                    MatchType = MatchType.Option_100,
                                    Price = 0.1f
                                }
                            }
                        },
                    }
                });

            // Wait until the report generation finished
            while (reportStatus.Status is not OperationStatus.Finished)
            {
                // Wait 5 seconds between check requests
                await Task.Delay(TimeSpan.FromSeconds(5));
                
                reportStatus =
                    await _crowdinApiClient.Reports
                        .CheckReportGenerationStatus(projectId, reportStatus.Identifier);
            }
            
            // Report generation task is finished -> download report
            DownloadLink link = await _crowdinApiClient.Reports.DownloadReport(projectId, reportStatus.Identifier);
            
            Console.WriteLine("Report created. Download link: {0} (expire in {1})", link.Url, link.ExpireIn);
        }
    }
}