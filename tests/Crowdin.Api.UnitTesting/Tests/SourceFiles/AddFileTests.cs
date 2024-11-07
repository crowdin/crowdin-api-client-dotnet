
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Crowdin.Api.Core;
using Crowdin.Api.SourceFiles;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.UnitTesting.Tests.SourceFiles
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
                    JsonObject = JObject.Parse(Resources.SourceFiles.AddFile_Response)
                });

            var executor = new SourceFilesApiExecutor(mockClient.Object);
            File responseFile = await executor.AddFile(projectId, body);

            Assert.NotNull(responseFile);
            Assert.IsType<SpreadsheetFileImportOptions>(responseFile.ImportOptions);
        }

        #region DocxFileImportOptions

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
                Context = "Additional context valuable for translators",
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
            string expectedRequestJson = TestUtils.CompactJson(Resources.SourceFiles.AddFile_Docx_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
        }

        [Fact]
        public void AddFile_DocxFileImportOptions_RequestDeserialization()
        {
            string requestJson = Resources.SourceFiles.AddFile_Docx_Request;
            var request = JsonConvert.DeserializeObject<AddFileRequest>(requestJson, JsonSettings);

            Assert.NotNull(request);
            Assert.IsType<DocxFileImportOptions>(request!.ImportOptions);

            var importOptions = (DocxFileImportOptions)request.ImportOptions!;
            Assert.True(importOptions.ContentSegmentation);
            Assert.Equal(1, importOptions.SrxStorageId);
        }

        #endregion

        #region HtmlFileImportOptions

        [Fact]
        public void AddFile_HtmlFileImportOptions_RequestSerialization()
        {
            var request = new AddFileRequest
            {
                StorageId = 1,
                ImportOptions = new HtmlFileImportOptions
                {
                    ExcludedElements = new List<string> { ".div" },
                    ContentSegmentation = true,
                    SrxStorageId = 2
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Resources.SourceFiles.AddFile_Html_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
        }

        [Fact]
        public void AddFile_HtmlFileImportOptions_RequestDeserialization()
        {
            string requestJson = Resources.SourceFiles.AddFile_Html_Request;
            var request = JsonConvert.DeserializeObject<AddFileRequest>(requestJson, JsonSettings);

            Assert.NotNull(request);
            Assert.IsType<HtmlFileImportOptions>(request!.ImportOptions);

            var importOptions = (HtmlFileImportOptions)request.ImportOptions!;
            Assert.Equal(new List<string> { ".div" }, importOptions.ExcludedElements);
            Assert.True(importOptions.ContentSegmentation);
            Assert.Equal(2, importOptions.SrxStorageId);
        }

        #endregion

        #region HtmlWithFrontMatterFileImportOptions

        [Fact]
        public void AddFile_HtmlWithFrontMatterFileImportOptions_RequestSerialization()
        {
            var request = new AddFileRequest
            {
                StorageId = 1,
                ImportOptions = new HtmlWithFrontMatterFileImportOptions
                {
                    ExcludedElements = new List<string> { ".div" },
                    ExcludedFrontMatterElements = new List<string> { "br" },
                    ContentSegmentation = true,
                    SrxStorageId = 2
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Resources.SourceFiles.AddFile_HtmlWithFrontMatter_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
        }

        [Fact]
        public void AddFile_HtmlWithFrontMatterFileImportOptions_RequestDeserialization()
        {
            string requestJson = Resources.SourceFiles.AddFile_HtmlWithFrontMatter_Request;
            var request = JsonConvert.DeserializeObject<AddFileRequest>(requestJson, JsonSettings);

            Assert.NotNull(request);
            Assert.IsType<HtmlWithFrontMatterFileImportOptions>(request!.ImportOptions);

            var importOptions = (HtmlWithFrontMatterFileImportOptions)request.ImportOptions!;
            Assert.Equal(new List<string> { ".div" }, importOptions.ExcludedElements);
            Assert.Equal(new List<string> { "br" }, importOptions.ExcludedFrontMatterElements);
            Assert.True(importOptions.ContentSegmentation);
            Assert.Equal(2, importOptions.SrxStorageId);
        }

        #endregion

        #region MdxV1FileImportOptions

        [Fact]
        public void AddFile_MdxV1FileImportOptions_RequestSerialization()
        {
            var request = new AddFileRequest
            {
                StorageId = 1,
                ImportOptions = new MdxV1FileImportOptions()
                {
                    ExcludedFrontMatterElements = new List<string> { "br" },
                    ExcludeCodeBlocks = true,
                    ContentSegmentation = true,
                    SrxStorageId = 2
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Resources.SourceFiles.AddFile_MdxV1_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
        }

        [Fact]
        public void AddFile_MdxV1FileImportOptions_RequestDeserialization()
        {
            string requestJson = Resources.SourceFiles.AddFile_MdxV1_Request;
            var request = JsonConvert.DeserializeObject<AddFileRequest>(requestJson, JsonSettings);

            Assert.NotNull(request);
            Assert.IsType<MdxV1FileImportOptions>(request!.ImportOptions);

            var importOptions = (MdxV1FileImportOptions)request.ImportOptions!;
            Assert.Equal(new List<string> { "br" }, importOptions.ExcludedFrontMatterElements);
            Assert.True(importOptions.ExcludeCodeBlocks);
            Assert.True(importOptions.ContentSegmentation);
            Assert.Equal(2, importOptions.SrxStorageId);
        }

        #endregion

        #region JavaScriptFileExportOptions

        [Fact]
        public void AddFile_JavascriptExportOptions_RequestSerialization()
        {
            var request = new AddFileRequest
            {
                StorageId = 1,
                Name = "fooFile.js",
                BranchId = 34,
                DirectoryId = 4,
                Title = "Foo File",
                Context = "Foo File Context",
                Type = ProjectFileType.Js,
                ExportOptions = new JavaScriptFileExportOptions()
                {
                    ExportPattern = "/files/fooFile.js",
                    ExportQuotes = ExportQuotesMode.ExportDoubleQuote
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Resources.SourceFiles.AddFile_JavaScript_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
        }

        [Fact]
        public void AddFile_JavaScriptExportOptions_RequestDeserialization()
        {
            string requestJson = Resources.SourceFiles.AddFile_JavaScript_Request;
            var request = JsonConvert.DeserializeObject<AddFileRequest>(requestJson, JsonSettings);

            Assert.NotNull(request);
            Assert.IsType<JavaScriptFileExportOptions>(request!.ExportOptions);

            var exportOptions = request.ExportOptions as JavaScriptFileExportOptions;
            Assert.Equal("/files/fooFile.js", exportOptions?.ExportPattern);
            Assert.Equal(ExportQuotesMode.ExportDoubleQuote, exportOptions?.ExportQuotes);
        }

        [Fact]
        public async Task AddFile_JavaScriptExportOptions()
        {
            const int projectId = 1;
            var body = new AddFileRequest
            {
                StorageId = 1,
                Name = "fooFile.js",
                BranchId = 34,
                DirectoryId = 4,
                Title = "Foo File",
                Context = "Foo File Context",
                Type = ProjectFileType.Js,
                ExportOptions = new JavaScriptFileExportOptions()
                {
                    ExportPattern = "/files/fooFile.js",
                    ExportQuotes = ExportQuotesMode.ExportDoubleQuote
                }
            };

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest($"/projects/{projectId}/files", body, null))
                .ReturnsAsync(new CrowdinApiResult()
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Resources.SourceFiles.AddFile_JavaScript_Response)
                });

            var executor = new SourceFilesApiExecutor(mockClient.Object);
            File responseFile = await executor.AddFile(projectId, body);

            Assert.NotNull(responseFile);
            Assert.IsType<JavaScriptFileExportOptions>(responseFile.ExportOptions);
            var exportOptions = responseFile.ExportOptions as JavaScriptFileExportOptions;
            Assert.Equal("/files/fooFile.js", exportOptions?.ExportPattern);
            Assert.Equal(ExportQuotesMode.ExportDoubleQuote, exportOptions?.ExportQuotes);
        }

        #endregion

        [Fact]
        public void AddFile_RequestSerialization()
        {
            string rightRequestJson = Resources.SourceFiles.AddFile_Request;

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
            string rightRequestJson = Resources.SourceFiles.AddFile_Request;

            JsonSerializerSettings options = TestUtils.CreateJsonSerializerOptions();

            var obj = JsonConvert.DeserializeObject<AddFileRequest>(rightRequestJson, options)!;

            Assert.NotNull(obj);
            Assert.IsType<SpreadsheetFileImportOptions>(obj.ImportOptions);
            Assert.Equal(4, (obj.ImportOptions as SpreadsheetFileImportOptions)!.Scheme!.Count);
        }
    }
}