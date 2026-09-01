using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.SourceFiles;

namespace Crowdin.Api.UnitTesting.Tests.SourceFiles
{
    public class DeleteJobsTests
    {
        private const long ProjectId = 1;
        private const long DirectoryId = 2;
        private const long FileId = 3;

        [Fact]
        public async Task DeleteDirectory_Asynchronously()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            var url = $"/projects/{ProjectId}/directories/{DirectoryId}";

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
                    JsonObject = CreateDeleteJobResponse("directoryId", DirectoryId, false)
                });

            var executor = new SourceFilesApiExecutor(mockClient.Object);
            DeleteJobStatus? response = await executor.DeleteDirectory(ProjectId, DirectoryId, true);

            AssertDeleteJobStatus(response, null, DirectoryId, null, null);
        }

        [Fact]
        public async Task DeleteDirectory_Synchronously()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            var url = $"/projects/{ProjectId}/directories/{DirectoryId}";

            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new SourceFilesApiExecutor(mockClient.Object);
            DeleteJobStatus? response = await executor.DeleteDirectory(ProjectId, DirectoryId, false);

            Assert.Null(response);
            mockClient.Verify(client => client.SendDeleteRequest(url, null), Times.Once);
        }

        [Fact]
        public async Task CheckDirectoryDeletionStatus()
        {
            const string jobIdentifier = "directory-job-id";
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            var url = $"/projects/{ProjectId}/directories/{DirectoryId}/jobs/{jobIdentifier}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = CreateDeleteJobResponse("directoryId", DirectoryId, false)
                });

            var executor = new SourceFilesApiExecutor(mockClient.Object);
            DeleteJobStatus response = await executor.CheckDirectoryDeletionStatus(ProjectId, DirectoryId, jobIdentifier);

            AssertDeleteJobStatus(response, null, DirectoryId, null, null);
        }

        [Fact]
        public async Task DeleteFile_Asynchronously()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            var url = $"/projects/{ProjectId}/files/{FileId}";

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
                    JsonObject = CreateDeleteJobResponse("fileId", FileId, true)
                });

            var executor = new SourceFilesApiExecutor(mockClient.Object);
            DeleteJobStatus? response = await executor.DeleteFile(ProjectId, FileId, true);

            AssertDeleteJobStatus(response, null, null, FileId, "File deletion failed");
        }

        [Fact]
        public async Task CheckFileDeletionStatus()
        {
            const string jobIdentifier = "file-job-id";
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            var url = $"/projects/{ProjectId}/files/{FileId}/jobs/{jobIdentifier}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = CreateDeleteJobResponse("fileId", FileId, true)
                });

            var executor = new SourceFilesApiExecutor(mockClient.Object);
            DeleteJobStatus response = await executor.CheckFileDeletionStatus(ProjectId, FileId, jobIdentifier);

            AssertDeleteJobStatus(response, null, null, FileId, "File deletion failed");
        }

        private static JObject CreateDeleteJobResponse(string attributeName, long attributeValue, bool includeError)
        {
            return new JObject(
                new JProperty("data", new JObject(
                    new JProperty("identifier", "job-id"),
                    new JProperty("status", "in_progress"),
                    new JProperty("progress", 100),
                    new JProperty("attributes", new JObject(new JProperty(attributeName, attributeValue))),
                    new JProperty("error", includeError
                        ? new JObject(new JProperty("message", "File deletion failed"))
                        : JValue.CreateNull()),
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