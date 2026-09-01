using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api;
using BranchResource = Crowdin.Api.Branches.Branch;
using BranchesApiExecutor = Crowdin.Api.Branches.BranchesApiExecutor;
using BranchesSearchParams = Crowdin.Api.Branches.BranchesSearchParams;
using Crowdin.Api.Core;
using Crowdin.Api.SourceFiles;
using Crowdin.Api.SourceStrings;
using Crowdin.Api.StringTranslations;

namespace Crowdin.Api.UnitTesting.Tests.Search
{
    public class SearchApiTests
    {
        [Fact]
        public async Task SearchBranches()
        {
            var @params = new BranchesSearchParams("master", new[] { 1L, 2L }, 3, 10, 20);
            IDictionary<string, string> queryParams = @params.ToQueryParams();

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest("/branches", queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.OrganizationSearch.SearchBranches_Response)
                });

            var executor = new BranchesApiExecutor(mockClient.Object);
            ResponseList<BranchResource> response = await executor.SearchBranches(@params);

            Assert.Equal("develop-master", response.Data.Single().Name);
            Assert.Equal(2, response.Data.Single().ProjectId);
            Assert.NotNull(response.Pagination);
            Assert.Equal(20, response.Pagination!.Offset);
            Assert.Equal(10, response.Pagination!.Limit);
        }

        [Fact]
        public async Task SearchDirectories()
        {
            var @params = new DirectoriesSearchParams("main", new[] { 1L, 2L }, 3, 10, 20);
            IDictionary<string, string> queryParams = @params.ToQueryParams();

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest("/directories", queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.OrganizationSearch.SearchDirectories_Response)
                });

            var executor = new SourceFilesApiExecutor(mockClient.Object);
            ResponseList<Directory> response = await executor.SearchDirectories(@params);

            Assert.Equal("main", response.Data.Single().Name);
            Assert.Equal(2, response.Data.Single().ProjectId);
            Assert.Equal(34, response.Data.Single().BranchId);
        }

        [Fact]
        public async Task SearchFiles()
        {
            var @params = new FilesSearchParams("xliff", new[] { 1L, 2L }, 3, 10, 20);
            IDictionary<string, string> queryParams = @params.ToQueryParams();

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest("/files", queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.OrganizationSearch.SearchFiles_Response)
                });

            var executor = new SourceFilesApiExecutor(mockClient.Object);
            ResponseList<FileInfoCollectionResource> response = await executor.SearchFiles(@params);

            Assert.Equal("umbrella_app.xliff", response.Data.Single().Name);
            Assert.Equal(2, response.Data.Single().ProjectId);
            Assert.Equal("/directory1/directory2/filename.extension", response.Data.Single().Path);
        }

        [Fact]
        public async Task SearchStrings()
        {
            var @params = new StringsSearchParams(
                "video",
                new[] { 1L, 2L },
                3,
                StringSearchScope.Context,
                1,
                10,
                20);
            IDictionary<string, string> queryParams = @params.ToQueryParams();

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest("/strings", queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.OrganizationSearch.SearchStrings_Response)
                });

            var executor = new SourceStringsApiExecutor(mockClient.Object);
            ResponseList<SourceString> response = await executor.SearchStrings(@params);

            SourceString stringResource = response.Data.Single();
            Assert.Equal("video.description", stringResource.Identifier);
            Assert.Equal("Not all videos are shown to users. See more", stringResource.Text);
            Assert.Equal(2, stringResource.ProjectId);
        }

        [Fact]
        public async Task SearchTranslations()
        {
            var @params = new TranslationsSearchParams(
                "translated",
                new[] { 1L, 2L },
                3,
                new[] { "uk", "de" },
                1,
                10,
                20);
            IDictionary<string, string> queryParams = @params.ToQueryParams();

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest("/translations", queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.OrganizationSearch.SearchTranslations_Response)
                });

            var executor = new StringTranslationsApiExecutor(mockClient.Object);
            ResponseList<TranslationSearchResource> response = await executor.SearchTranslations(@params);

            TranslationSearchResource translation = response.Data.Single();
            Assert.Equal(8, translation.ProjectId);
            Assert.Equal(35, translation.StringId);
            Assert.Equal("uk", translation.LanguageId);
            Assert.Equal("Цю стрічку перекладено", translation.Text);
            Assert.Equal(17, translation.ProviderId);
            Assert.Equal(75, translation.MatchRate);
            Assert.Equal("fuzzy", translation.MatchType);
            Assert.Equal(77, translation.WorkflowStepId);
        }

        [Fact]
        public void SearchStringsQueryParams()
        {
            var @params = new StringsSearchParams(
                "video",
                new[] { 1L, 2L },
                3,
                StringSearchScope.Key,
                1,
                10,
                20);

            Assert.Equal(
                "limit=10&offset=20&filter=video&projectIds=1,2&userId=3&scope=key&denormalizePlaceholders=1",
                @params.ToQueryParams().ToQueryString());
        }

        [Fact]
        public void SearchTranslationsQueryParams()
        {
            var @params = new TranslationsSearchParams(
                "translated",
                new[] { 1L, 2L },
                3,
                new[] { "uk", "de" },
                1,
                10,
                20);

            Assert.Equal(
                "limit=10&offset=20&filter=translated&projectIds=1,2&userId=3&languageIds=uk,de&denormalizePlaceholders=1",
                @params.ToQueryParams().ToQueryString());
        }
    }
}
