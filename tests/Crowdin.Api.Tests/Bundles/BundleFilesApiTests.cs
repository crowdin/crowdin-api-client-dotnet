
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Bundles;
using Crowdin.Api.Core;
using Crowdin.Api.SourceFiles;
using Crowdin.Api.Tests.Testing;

namespace Crowdin.Api.Tests.Bundles
{
    public class BundleFilesApiTests
    {
        private const int ProjectId = 2;
        private const int BundleId = 1;
        
        [Fact]
        public async Task ListFiles_AsTranslatorOrProofreader()
        {
            var file = await ExecuteForType<FileInfoCollectionResource>(
                Testing.Resources.Bundles.ListBundleFiles_Response_AsTranslator);
            
            Assert.Equal(ProjectId, file.ProjectId);
            Assert.Equal(FileStatus.Active, file.Status);
        }
        
        [Fact]
        public async Task ListFiles_AsProjectOwnerOrManager()
        {
            var file = await ExecuteForType<FileCollectionResource>(
                Testing.Resources.Bundles.ListBundleFiles_Response_AsProjectOwner);
            
            Assert.Equal(Priority.Normal, file.Priority);
            Assert.NotNull(file.ImportOptions);
            Assert.NotNull(file.ExportOptions);
            Assert.Equal(3, file.ExcludedTargetLanguages.Length);
        }
        
        private static async Task<T> ExecuteForType<T>(string resourceId) where T : FileResourceBase
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/projects/{ProjectId}/bundles/{BundleId}/files";
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            
            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(resourceId)
                });
            
            var executor = new BundlesApiExecutor(mockClient.Object);
            ResponseList<T> response = await executor.BundleListFiles<T>(ProjectId, BundleId);
            
            Assert.Single(response.Data);
            T file = response.Data.First();
            return file;
        }
    }
}