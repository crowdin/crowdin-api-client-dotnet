
using Crowdin.Api.Reports;
using Crowdin.Api.Tests.Core;
using Newtonsoft.Json;
using Xunit;

namespace Crowdin.Api.Tests.Reports
{
    public class ReportsApiTests
    {
        [Fact]
        public void GenerateReport_RequestSerialization()
        {
            var request = new CostEstimateGenerateReportRequest
            {
                Schema = new CostEstimateGenerateReportRequest.GeneralSchema
                {
                    Currency = ReportCurrency.UAH
                }
            };

            JsonSerializerSettings settings = TestUtils.CreateJsonSerializerOptions();
            string requestJson = JsonConvert.SerializeObject(request, settings);
            
            Assert.NotNull(requestJson);
            Assert.Equal(Core.Resources.Reports.GenerateReport_Request, requestJson);
        }
    }
}