using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Branches;
using Crowdin.Api.Core;

namespace Crowdin.Api.UnitTesting.Tests.Branches
{
    public class BranchDeletionTests
    {
        private const long ProjectId = 1;
        private const long BranchId = 2;

        [Fact]
        public async Task DeleteBranch_Asynchronously()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            var url = $"/projects/{ProjectId}/branches/{BranchId}";

            mockClient
                .Setup(client => client.SendDeleteRequest_FullResult(
                    url,
                    null,
                    It.Is<IDictionary<string, string>>(headers =>
                        headers.Count == 1 &&
                        headers.ContainsKey("Prefer") &&
                        headers["Prefer"] == "respond-async")))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Accepted,
                    JsonObject = CreateDeleteJobResponse("branchId", BranchId)
                });

            var executor = new BranchesApiExecutor(mockClient.Object);
            DeleteJobStatus? response = await executor.DeleteBranch(ProjectId, BranchId, true);

            AssertDeleteJobStatus(response, BranchId, null, null, null);
        }

        [Fact]
        public async Task CheckBranchDeletionStatus()
        {
            const string jobIdentifier = "job-id";
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            var url = $"/projects/{ProjectId}/branches/{BranchId}/jobs/{jobIdentifier}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = CreateDeleteJobResponse("branchId", BranchId)
                });

            var executor = new BranchesApiExecutor(mockClient.Object);
            DeleteJobStatus response = await executor.CheckBranchDeletionStatus(ProjectId, BranchId, jobIdentifier);

            AssertDeleteJobStatus(response, BranchId, null, null, null);
        }

        private static JObject CreateDeleteJobResponse(string attributeName, long attributeValue)
        {
            return new JObject(
                new JProperty("data", new JObject(
                    new JProperty("identifier", "job-id"),
                    new JProperty("status", "in_progress"),
                    new JProperty("progress", 100),
                    new JProperty("attributes", new JObject(new JProperty(attributeName, attributeValue))),
                    new JProperty("error", JValue.CreateNull()),
                    new JProperty("createdAt", "2019-09-23T11:26:54+00:00"),
                    new JProperty("updatedAt", "2019-09-23T11:26:54+00:00"),
                    new JProperty("startedAt", "2019-09-23T11:26:54+00:00"),
                    new JProperty("finishedAt", "2019-09-23T11:26:54+00:00"))));
        }

        private static void AssertDeleteJobStatus(
            DeleteJobStatus? status,
            long? branchId,
            long? directoryId,
            long? fileId,
            string? errorMessage)
        {
            Assert.NotNull(status);
            Assert.Equal("job-id", status!.Identifier);
            Assert.Equal(OperationStatus.InProgress, status.Status);
            Assert.Equal(100, status.Progress);
            Assert.Equal(branchId, status.Attributes.BranchId);
            Assert.Equal(directoryId, status.Attributes.DirectoryId);
            Assert.Equal(fileId, status.Attributes.FileId);
            Assert.Equal(errorMessage, status.Error?.Message);
            DateTimeOffset date = DateTimeOffset.Parse("2019-09-23T11:26:54+00:00");
            Assert.Equal(date, status.CreatedAt);
            Assert.Equal(date, status.UpdatedAt);
            Assert.Equal(date, status.StartedAt);
            Assert.Equal(date, status.FinishedAt);
        }
    }
}