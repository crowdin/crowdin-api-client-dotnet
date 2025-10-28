
using System;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Branches;
using Crowdin.Api.Core;

namespace Crowdin.Api.UnitTesting.Tests.Branches
{
    public class BranchesOperationsApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task GetClonedBranch()
        {
            const int projectId = 1;
            const int branchId = 2;
            const string cloneId = "id";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/branches/{branchId}/clones/{cloneId}/branch";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Branches.Response_Common_Single)
                });

            var executor = new BranchesApiExecutor(mockClient.Object);
            Branch response = await executor.GetClonedBranch(projectId, branchId, cloneId);

            Assert_Branch(response);
        }

        [Fact]
        public async Task CloneBranch()
        {
            const int projectId = 1;
            const int branchId = 2;

            var request = new CloneBranchRequest
            {
                Name = "develop-master",
                Title = "Master branch"
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Resources.Branches.Request_CloneBranch);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/branches/{branchId}/clones";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Accepted,
                    JsonObject = JObject.Parse(Resources.Branches.Response_BranchCloneStatus)
                });

            var executor = new BranchesApiExecutor(mockClient.Object);
            BranchCloneStatus response = await executor.CloneBranch(projectId, branchId, request);

            Assert_BranchCloneStatus(response);
        }

        [Fact]
        public async Task CheckBranchCloneStatus()
        {
            const int projectId = 1;
            const int branchId = 2;
            const string cloneId = "id";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/branches/{branchId}/clones/{cloneId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Branches.Response_BranchCloneStatus)
                });

            var executor = new BranchesApiExecutor(mockClient.Object);
            BranchCloneStatus response = await executor.CheckBranchCloneStatus(projectId, branchId, cloneId);

            Assert_BranchCloneStatus(response);
        }

        [Fact]
        public async Task MergeBranch()
        {
            const int projectId = 1;
            const int branchId = 2;

            var request = new MergeBranchRequest
            {
                DeleteAfterMerge = true,
                SourceBranchId = 8,
                DryRun = true,
                AcceptSourceChanges = true
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Resources.Branches.Request_MergeBranch);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/branches/{branchId}/merges";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Accepted,
                    JsonObject = JObject.Parse(Resources.Branches.Response_BranchMergeStatus)
                });

            var executor = new BranchesApiExecutor(mockClient.Object);
            BranchMergeStatus response = await executor.MergeBranch(projectId, branchId, request);

            Assert_BranchMergeStatus(response);
        }

        [Fact]
        public async Task CheckBranchMergeStatus()
        {
            const int projectId = 1;
            const int branchId = 2;
            const string mergeId = "id";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/branches/{branchId}/merges/{mergeId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Branches.Response_BranchMergeStatus)
                });

            var executor = new BranchesApiExecutor(mockClient.Object);
            BranchMergeStatus response = await executor.CheckBranchMergeStatus(projectId, branchId, mergeId);

            Assert_BranchMergeStatus(response);
        }

        [Fact]
        public async Task GetBranchMergeSummary()
        {
            const int projectId = 1;
            const int branchId = 2;
            const string mergeId = "id";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/branches/{branchId}/merges/{mergeId}/summary";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Branches.Response_BranchMergeSummary)
                });

            var executor = new BranchesApiExecutor(mockClient.Object);
            BranchMergeSummary response = await executor.GetBranchMergeSummary(projectId, branchId, mergeId);

            Assert_BranchMergeSummary(response);
        }

        private static void Assert_Branch(Branch? branch)
        {
            ArgumentNullException.ThrowIfNull(branch);

            Assert.Equal(34, branch.Id);
            Assert.Equal(2, branch.ProjectId);
            Assert.Equal("develop-master", branch.Name);
            Assert.Equal("Master branch", branch.Title);
            Assert.Equal(DateTimeOffset.Parse("2019-09-16T13:48:04+00:00"), branch.CreatedAt);
            Assert.Equal(DateTimeOffset.Parse("2019-09-19T13:25:27+00:00"), branch.UpdatedAt);
        }

        private static void Assert_BranchCloneStatus(BranchCloneStatus? status)
        {
            ArgumentNullException.ThrowIfNull(status);

            Assert.Equal("50fb3506-4127-4ba8-8296-f97dc7e3e0c3", status.Identifier);
            Assert.Equal(OperationStatus.Finished, status.Status);
            Assert.Equal(100, status.Progress);
            Assert.NotNull(status.Attributes);

            DateTimeOffset date = DateTimeOffset.Parse("2019-09-23T11:26:54+00:00");
            Assert.Equal(date, status.CreatedAt);
            Assert.Equal(date, status.UpdatedAt);
            Assert.Equal(date, status.StartedAt);
            Assert.Equal(date, status.FinishedAt);
        }

        private static void Assert_BranchMergeStatus(BranchMergeStatus? status)
        {
            ArgumentNullException.ThrowIfNull(status);

            Assert.Equal("50fb3506-4127-4ba8-8296-f97dc7e3e0c3", status.Identifier);
            Assert.Equal(OperationStatus.Finished, status.Status);
            Assert.Equal(100, status.Progress);

            BranchMergeStatus.AttributesData? attributes = status.Attributes;
            ArgumentNullException.ThrowIfNull(status.Attributes);
            Assert.Equal(38, attributes.SourceBranchId);
            Assert.False(attributes.DeleteAfterMerge);
            Assert.False(attributes.AcceptSourceChanges);

            DateTimeOffset date = DateTimeOffset.Parse("2019-09-23T11:26:54+00:00");
            Assert.Equal(date, status.CreatedAt);
            Assert.Equal(date, status.UpdatedAt);
            Assert.Equal(date, status.StartedAt);
            Assert.Equal(date, status.FinishedAt);
        }

        private static void Assert_BranchMergeSummary(BranchMergeSummary? summary)
        {
            ArgumentNullException.ThrowIfNull(summary);

            Assert.Equal(BranchMergeStatusId.Merged, summary.Status);
            Assert.Equal(100, summary.SourceBranchId);
            Assert.Equal(100, summary.TargetBranchId);
            Assert.False(summary.DryRun);

            BranchMergeSummary.DetailsData? details = summary.Details;
            ArgumentNullException.ThrowIfNull(details);
            Assert.Equal(1, details.Added);
            Assert.Equal(2, details.Deleted);
            Assert.Equal(3, details.Updated);
            Assert.Equal(7, details.Conflicted);
        }
    }
}