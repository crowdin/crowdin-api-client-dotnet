
using Crowdin.Api.Reports;

namespace Crowdin.Api.Samples.Actions
{
    public partial class CrowdinActions
    {
        public async Task GenerateReport(int projectId, int directoryId, int fileId)
        {
            // Start report generation task
            ReportStatus? reportStatus = await _crowdinApiClient.Reports.GenerateReport(
                projectId,
                new CostEstimateGenerateReportRequest
                {
                    Schema = new CostEstimateGenerateReportRequest.GeneralSchema
                    {
                        Unit = ReportUnit.Words,
                        Currency = ReportCurrency.USD,
                        Format = ReportFormat.Xlsx,
                        LanguageId = "uk",
                        FileIds = new[] { fileId },
                        DirectoryIds = new[] { directoryId },
                        DateFrom = DateTimeOffset.Parse("2019-09-23T07:00:14+00:00"),
                        LabelIncludeType = ReportLabelIncludeType.StringsWithLabel
                    }
                });

            // Wait until the report generation finished
            while (reportStatus.Status is not "finished")
            {
                // Wait 5 seconds between check requests
                await Task.Delay(TimeSpan.FromSeconds(5));
                
                reportStatus =
                    await _crowdinApiClient.Reports
                        .CheckReportGenerationStatus(projectId, reportStatus.Identifier);
            }
            
            // Report generation task is finished -> download report
            DownloadLink? link = await _crowdinApiClient.Reports.DownloadReport(projectId, reportStatus.Identifier);
            
            Console.WriteLine("Report created. Download link: {0} (expire in {1})", link.Url, link.ExpireIn);
        }
    }
}