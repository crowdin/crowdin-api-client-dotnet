
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.SourceFiles;
using Crowdin.Api.Tests.Core;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.Tests.SourceFiles
{
    public class AddFileTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();
        
        [Fact]
        public async Task AddFile()
        {
            const int projectId = 1;
            
            var body = new AddFileRequest
            {
                StorageId = 1,
                Name = "Test name",
                ImportOptions = new SpreadsheetFileImportOptions
                {
                    Scheme = new Dictionary<string, int>
                    {
                        { "context", 123 },
                        { "ua", 1 },
                        { "ru", 2 },
                        { "en", 3 }
                    }
                }
            };
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            mockClient
                .Setup(client => client.SendPostRequest($"/projects/{projectId}/files", body, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Core.Resources.SourceFiles.AddFile_Response)
                });

            var executor = new SourceFilesApiExecutor(mockClient.Object);
            File responseFile = await executor.AddFile(projectId, body);
            
            Assert.NotNull(responseFile);
            Assert.IsType<SpreadsheetFileImportOptions>(responseFile.ImportOptions);
        }

        [Fact]
        public void AddFile_DocxFileImportOptions_RequestSerialization()
        {
            var request = new AddFileRequest
            {
                StorageId = 61,
                Name = "umbrella_app.docx",
                BranchId = 34,
                DirectoryId = 4,
                Title = "source_app_info",
                Type = ProjectFileType.DocX,
                ImportOptions = new DocxFileImportOptions
                {
                    CleanTagsAggressively = false,
                    TranslateHiddenRowsAndColumns = null,
                    ContentSegmentation = true,
                    SrxStorageId = 1
                },
                ExcludedTargetLanguages = new List<string>() { "en", "es", "pl" },
                AttachLabelIds = new[] { 1 }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.SourceFiles.AddFile_Docx_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
        }
        
        [Fact]
        public void AddFile_RequestSerialization()
        {
            string rightRequestJson = Core.Resources.SourceFiles.AddFile_Request;

            var body = new AddFileRequest
            {
                StorageId = 1,
                Name = "Test name",
                ImportOptions = new SpreadsheetFileImportOptions
                {
                    Scheme = new Dictionary<string, int>
                    {
                        { "context", 123 },
                        { "ua", 1 },
                        { "ru", 2 },
                        { "en", 3 }
                    }
                }
            };

            JsonSerializerSettings options = TestUtils.CreateJsonSerializerOptions();

            string requestJson = JsonConvert.SerializeObject(body, options);
            Assert.Equal(rightRequestJson, requestJson);
        }

        [Fact]
        public void AddFile_RequestDeserialization()
        {
            string rightRequestJson = Core.Resources.SourceFiles.AddFile_Request;

            JsonSerializerSettings options = TestUtils.CreateJsonSerializerOptions();

            var obj = JsonConvert.DeserializeObject<AddFileRequest>(rightRequestJson, options)!;
            
            Assert.NotNull(obj);
            Assert.IsType<SpreadsheetFileImportOptions>(obj.ImportOptions);
            Assert.Equal(4, (obj.ImportOptions as SpreadsheetFileImportOptions)!.Scheme!.Count);
        }
    }
}