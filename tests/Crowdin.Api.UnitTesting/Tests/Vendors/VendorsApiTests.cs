
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.Vendors;

namespace Crowdin.Api.UnitTesting.Tests.Vendors
{
    public class VendorsApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task ListVendors()
        {
            const int vendorId = 52;
            const string name = "Vendor Name";
            const string description = "Vendor Description";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/vendors";
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Vendors.ListVendorsResponse)
                });

            var executor = new VendorsApiExecutor(mockClient.Object);
            ResponseList<Vendor>? response = await executor.ListVendors();

            Assert.NotNull(response);
            Assert.Single(response.Data);
            Assert.IsType<Vendor>(response.Data[0]);
            Assert.Equal(vendorId, response.Data[0].Id);
            Assert.Equal(name, response.Data[0].Name);
            Assert.Equal(description, response.Data[0].Description);
            Assert.Equal(VendorStatus.Confirmed, response.Data[0].Status);
        }

        [Fact]
        public void VendorStatuses()
        {
            SerializeAndAssert(VendorStatus.Pending, "pending");
            SerializeAndAssert(VendorStatus.Confirmed, "confirmed");
            SerializeAndAssert(VendorStatus.Rejected, "rejected");
            SerializeAndAssert(VendorStatus.Deleted, "deleted");
        }

        private static void SerializeAndAssert(Enum enumValue, string expectedValueString)
        {
            string actualValueString = TestUtils.SerializeValue(enumValue, JsonSettings);
            Assert.Equal(expectedValueString, actualValueString);
        }
    }
}
