
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.SecurityLogs;

namespace Crowdin.Api.UnitTesting.Tests.SecurityLogs
{
    public class SecurityLogsApiTests
    {
        [Fact]
        public async Task ListUserSecurityLogs()
        {
            const long userId = 1;
            const SecurityLogEventType eventType = SecurityLogEventType.ApplicationConnected;
            const string ipAddress = "127.0.0.1";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/security-logs";

            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            queryParams.AddDescriptionEnumValueIfPresent<SecurityLogEventType>("event", eventType);
            queryParams.AddParamIfPresent("ipAddress", ipAddress);

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.SecurityLogs.ListUserSecurityLogs_Response)
                });

            var executor = new SecurityLogsApiExecutor(mockClient.Object);
            ResponseList<SecurityLog> response = await executor.ListUserSecurityLogs(
                userId,
                eventType: eventType,
                ipAddress: ipAddress);

            Assert.NotNull(response);
            Assert.Single(response.Data);
            Assert_SecurityLog(response.Data[0]);
        }

        [Fact]
        public async Task GetUserSecurityLog()
        {
            const long userId = 1;
            const long securityLogId = 2;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/security-logs/{securityLogId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.SecurityLogs.GetUserSecurityLog_Response)
                });

            var executor = new SecurityLogsApiExecutor(mockClient.Object);
            SecurityLog response = await executor.GetUserSecurityLog(userId, securityLogId);

            Assert_SecurityLog(response);
        }

        [Fact]
        public async Task ListOrganizationSecurityLogs()
        {
            const SecurityLogEventType eventType = SecurityLogEventType.SsoConnect;
            const string ipAddress = "127.0.0.1";
            const long userId = 123;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            queryParams.AddDescriptionEnumValueIfPresent<SecurityLogEventType>("event", eventType);
            queryParams.AddParamIfPresent("ipAddress", ipAddress);
            queryParams.AddParamIfPresent("userId", userId);

            mockClient
                .Setup(client => client.SendGetRequest("/security-logs", queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.SecurityLogs.ListUserSecurityLogs_Response)
                });

            var executor = new SecurityLogsApiExecutor(mockClient.Object);
            ResponseList<SecurityLog> response = await executor.ListOrganizationSecurityLogs(
                eventType: eventType,
                ipAddress: ipAddress,
                userId: userId);

            Assert.NotNull(response);
            Assert.Single(response.Data);
            Assert_SecurityLog(response.Data[0]);
        }

        [Fact]
        public async Task GetOrganizationSecurityLog()
        {
            const long securityLogId = 1;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/security-logs/{securityLogId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.SecurityLogs.GetUserSecurityLog_Response)
                });

            var executor = new SecurityLogsApiExecutor(mockClient.Object);
            SecurityLog response = await executor.GetOrganizationSecurityLog(securityLogId);

            Assert_SecurityLog(response);
        }

        private static void Assert_SecurityLog(SecurityLog log)
        {
            Assert.Equal(2, log.Id);
            Assert.Equal(SecurityLogEventType.ApplicationConnected, log.Event);
            Assert.Equal("Some info", log.Info);
            Assert.Equal(4, log.UserId);
            Assert.Equal("USA", log.Location);
            Assert.Equal("127.0.0.1", log.IpAddress);
            Assert.Equal("MacOs on MacBook", log.DeviceName);
            Assert.Equal(DateTimeOffset.Parse("2019-09-19T15:10:43+00:00"), log.CreatedAt);
        }
    }
}