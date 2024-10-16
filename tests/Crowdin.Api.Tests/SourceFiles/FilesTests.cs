using System;
using System.Collections.Generic;
using Crowdin.Api.SourceFiles;
using Crowdin.Api.Tests.Testing;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Crowdin.Api.Core;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using Xunit;
using Moq;

namespace Crowdin.Api.Tests.SourceFiles {
    public class FilesTests {
        private const int projectId = 1;
        private const int fileId = 2;
        private const int directoryId = 3;
        private const int revisionId = 4;

        private async Task ListFileHelper<T>(JObject jObject) where T : FileResourceBase {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            FilesListParams filesListParams = new();
            IDictionary<string, string> queryParams = filesListParams.ToQueryParams();

            mockClient
                .Setup(client => client.SendGetRequest($"/projects/{projectId}/files", queryParams))
                .ReturnsAsync(new CrowdinApiResult() {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = jObject
                });

            var executor = new SourceFilesApiExecutor(mockClient.Object);

            var result = await executor.ListFiles<T>(projectId);

            Assert.NotNull(result);
            Assert.IsType<ResponseList<T>>(result);
        }

        [Fact]
        public async Task ListFiles_FileInfoCollectionResource() =>
            await ListFileHelper<FileInfoCollectionResource>(JObject.Parse(@"
                {
                  ""data"": [
                    {
                      ""data"": {
                        ""id"": 44,
                        ""projectId"": 2,
                        ""branchId"": 34,
                        ""directoryId"": 4,
                        ""name"": ""umbrella_app.xliff"",
                        ""title"": ""source_app_info"",
                        ""type"": ""xliff"",
                        ""path"": ""/directory1/directory2/filename.extension"",
                        ""status"": ""active""
                      }
                    }
                  ],
                  ""pagination"": {
                    ""offset"": 0,
                    ""limit"": 25
                  }
                }
            "));

        [Fact]
        public async Task ListFiles_FileCollectionResourcee() =>
            await ListFileHelper<FileCollectionResource>(JObject.Parse(@"
                {
                  ""data"": [
                    {
                      ""data"": {
                        ""id"": 44,
                        ""projectId"": 2,
                        ""branchId"": 34,
                        ""directoryId"": 4,
                        ""name"": ""umbrella_app.xliff"",
                        ""title"": ""source_app_info"",
                        ""type"": ""xliff"",
                        ""path"": ""/directory1/directory2/filename.extension"",
                        ""status"": ""active"",
                        ""revisionId"": 1,
                        ""priority"": ""normal"",
                        ""importOptions"": {
                          ""firstLineContainsHeader"": false,
                          ""importTranslations"": false,
                          ""scheme"": {
                            ""identifier"": 0,
                            ""sourcePhrase"": 1,
                            ""en"": 2,
                            ""de"": 3
                          }
                        },
                        ""exportOptions"": {
                          ""exportPattern"": ""/localization/%locale%/%file_name%.%file_extension%""
                        },
                        ""excludedTargetLanguages"": [
                          ""en"",
                          ""es"",
                          ""pl""
                        ],
                        ""createdAt"": ""2019-09-19T15:10:43+00:00"",
                        ""updatedAt"": ""2019-09-19T15:10:46+00:00""
                      }
                    }
                  ],
                  ""pagination"": {
                    ""offset"": 0,
                    ""limit"": 25
                  }
                }
            "));

        [Fact]
        public async Task AddFile() {
            var mockResponseObject = JObject.Parse(Testing.Resources.SourceFiles.AddFile_Response);

            var request = new AddFileRequest() {
                StorageId = 61,
                Name = "umbrella_app.xliff",
                ImportOptions = new SpreadsheetFileImportOptions {
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
                .Setup(client => client.SendPostRequest($"/projects/{projectId}/files", request, null))
                .ReturnsAsync(new CrowdinApiResult {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = mockResponseObject
                });

            SourceFilesApiExecutor executor = new(mockClient.Object, mockClient.Object.DefaultJsonParser);
            var result = await executor.AddFile(projectId, request);

            Assert.NotNull(result);
            Assert.IsType<File>(result);
            Assert.Equal("umbrella_app.xliff", result.Name);
            Assert.IsType<SpreadsheetFileImportOptions>(result.ImportOptions);
        }

        [Fact]
        public async Task EditFile() {
            var patches = new List<FilePatch>
            {
                new FilePatch
                {
                    Operation = PatchOperation.Replace,
                    Path = FilePatchPath.Priority,
                    Value = Priority.High
                },
                new FilePatch
                {
                    Operation = PatchOperation.Replace,
                    Path = FilePatchPath.DirectoryId,
                    Value = directoryId
                }
            };

            var options = TestUtils.CreateJsonSerializerOptions();
            string requestJson = JsonConvert.SerializeObject(patches, options);
            string rightRequestJson = Testing.Resources.SourceFiles.EditFile_Request;
            Assert.Equal(rightRequestJson, requestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client
                    .SendPatchRequest($"/projects/{projectId}/files/{fileId}", patches, null))
                .ReturnsAsync(new CrowdinApiResult {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Testing.Resources.SourceFiles.EditFile_Response)
                });

            var executor = new SourceFilesApiExecutor(mockClient.Object);

            File fileResponse = await executor.EditFile(projectId, fileId, patches);

            Assert.NotNull(fileResponse);
            Assert.IsType<GeneralFileExportOptions>(fileResponse.ExportOptions);
            Assert.IsType<SpreadsheetFileImportOptions>(fileResponse.ImportOptions);
        }

        [Fact]
        public async Task EditFile_JavaScriptExportOptions()
        {
            //Add a new JS file
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
                .Setup(client => client.SendPostRequest($"/projects/2/files", body, null))
                .ReturnsAsync(new CrowdinApiResult()
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Testing.Resources.SourceFiles.AddFile_JavaScript_Response)
                });

            //Edit the file export options of the newly created JS file 
            var patches = new List<FilePatch>
            {
                new FilePatch
                {
                    Operation = PatchOperation.Replace,
                    Path = FilePatchPath.ExportQuotes,
                    Value = ExportQuotesMode.ExportSingleQuote
                }
            };
            var options = TestUtils.CreateJsonSerializerOptions();
            string actualRequestJson = JsonConvert.SerializeObject(patches, options);
            string expectedRequestJson = Testing.Resources.SourceFiles.EditFile_JavaScriptRequest;
            Assert.Equal(actualRequestJson, expectedRequestJson);

            mockClient
                .Setup(client => client
                    .SendPatchRequest($"/projects/2/files/44", patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Testing.Resources.SourceFiles.EditFile_JavaScript_Response)
                });

            var executor = new SourceFilesApiExecutor(mockClient.Object);
            File fileResponse = await executor.EditFile(2, 44, patches);
            var exportOptions = fileResponse.ExportOptions as JavaScriptFileExportOptions;

            //Assert
            Assert.NotNull(fileResponse);
            Assert.IsType<JavaScriptFileExportOptions>(fileResponse.ExportOptions);
            Assert.Equal(ExportQuotesMode.ExportSingleQuote, exportOptions!.ExportQuotes);
}

        private async Task GetFileHelper<T>(JObject jObject) where T : FileInfoResource {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendGetRequest($"/projects/{projectId}/files/{fileId}", null))
                .ReturnsAsync(new CrowdinApiResult() {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = jObject
                });

            var executor = new SourceFilesApiExecutor(mockClient.Object);

            var result = await executor.GetFile<T>(projectId, fileId);
            Assert.NotNull(result);
            Assert.IsType<T>(result);
        }

        [Fact]
        public async Task GetFile_FileInfoResource() =>
            await GetFileHelper<FileInfoResource>(JObject.Parse(@"
                {
                    ""data"": {
                        ""id"": 44,
                        ""projectId"": 2,
                        ""branchId"": 34,
                        ""directoryId"": 4,
                        ""name"": ""umbrella_app.xliff"",
                        ""title"": ""source_app_info"",
                        ""type"": ""xliff"",
                        ""path"": ""/directory1/directory2/filename.extension"",
                        ""status"": ""active""
                    }
                }
            "));

        [Fact]
        public async Task GetFile_FileResource() =>
            await GetFileHelper<FileResource>(JObject.Parse(@"
                {
                  ""data"": {
                    ""id"": 44,
                    ""projectId"": 2,
                    ""branchId"": 34,
                    ""directoryId"": 4,
                    ""name"": ""umbrella_app.xliff"",
                    ""title"": ""source_app_info"",
                    ""type"": ""xliff"",
                    ""path"": ""/directory1/directory2/filename.extension"",
                    ""status"": ""active"",
                    ""revisionId"": 1,
                    ""priority"": ""normal"",
                    ""importOptions"": {
                      ""firstLineContainsHeader"": false,
                      ""importTranslations"": false,
                      ""scheme"": {
                        ""identifier"": 0,
                        ""sourcePhrase"": 1,
                        ""en"": 2,
                        ""de"": 3
                      }
                    },
                    ""excludedTargetLanguages"": [
                      ""en"",
                      ""es"",
                      ""pl""
                    ],
                    ""createdAt"": ""2019-09-19T15:10:43+00:00"",
                    ""updatedAt"": ""2019-09-19T15:10:46+00:00""
                  }
                }
            "));

        [Fact]
        public async Task DeleteFile_Throw() {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendDeleteRequest($"/projects/{projectId}/files/{fileId}", null))
                .ReturnsAsync(HttpStatusCode.Unauthorized);

            var executor = new SourceFilesApiExecutor(mockClient.Object);

            await Assert.ThrowsAsync<CrowdinApiException>(async () => await executor.DeleteFile(projectId, fileId));
        }

        [Fact]
        public async Task DeleteFile() {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendDeleteRequest($"/projects/{projectId}/files/{fileId}", null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new SourceFilesApiExecutor(mockClient.Object);

            try {
                await executor.DeleteFile(projectId, fileId);
            } catch (CrowdinApiException e) {
                Assert.True(false, e.Message);
                return;
            }

            Assert.True(true);
        }

        [Fact]
        public async Task DownloadFile() {
            var mockResponseObject = JObject.Parse(@"
                {
                    ""data"": {
                        ""url"": ""https://production-enterprise-importer.downloads.crowdin.com/992000002/2/14.xliff?response-content-disposition=attachment%3B%20filename%3D%22APP.xliff%22&X-Amz-Content-Sha256=UNSIGNED-PAYLOAD&X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAIGJKLQV66ZXPMMEA%2F20190920%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20190920T093121Z&X-Amz-SignedHeaders=host&X-Amz-Expires=3600&X-Amz-Signature=439ebd69a1b7e4c23e6d17891a491c94f832e0c82e4692dedb35a6cd1e624b62"",
                        ""expireIn"": ""2019-09-20T10:31:21+00:00""
                    }
                }
            ");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendGetRequest($"/projects/{projectId}/files/{fileId}/download", null))
                .ReturnsAsync(new CrowdinApiResult() {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = mockResponseObject
                });

            var executor = new SourceFilesApiExecutor(mockClient.Object);

            var result = await executor.DownloadFile(projectId, fileId);

            Assert.NotNull(result);
            Assert.IsType<DownloadLink>(result);
        }

        [Fact]
        public async Task DownloadFilePreview()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/projects/{projectId}/files/{fileId}/preview";
            
            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Testing.Resources.SourceFiles.DownloadFilePreview_Response)
                });
            
            var executor = new SourceFilesApiExecutor(mockClient.Object);
            DownloadLink response = await executor.DownloadFilePreview(projectId, fileId);
            
            Assert.NotNull(response);
            Assert.StartsWith("https", response.Url);
            Assert.Equal(DateTimeOffset.Parse("2019-09-20T10:31:21+00:00"), response.ExpireIn);
        }

        [Fact]
        public async Task GetFileRevision() {
            var mockResponseObject = JObject.Parse(@"
                {
                    ""data"": {
                        ""id"": 2,
                        ""projectId"": 2,
                        ""fileId"": 248,
                        ""restoreToRevision"": null,
                        ""info"": {},
                        ""date"": ""2019-09-20T09:08:16+00:00""
                    }
                }
            ");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
               .Setup(client => client.SendGetRequest($"/projects/{projectId}/files/{fileId}/revisions/{revisionId}", null))
               .ReturnsAsync(new CrowdinApiResult() {
                   StatusCode = HttpStatusCode.OK,
                   JsonObject = mockResponseObject
               });

            var executor = new SourceFilesApiExecutor(mockClient.Object);

            var result = await executor.GetFileRevision(projectId, fileId, revisionId);

            Assert.NotNull(result);
            Assert.IsType<RevisionResource>(result);
        }

        [Fact]
        public async Task ListFileRevisions() {
            var mockResponseObject = JObject.Parse(@"
                {
                  ""data"": [
                    {
                      ""data"": {
                        ""id"": 2,
                        ""projectId"": 2,
                        ""fileId"": 248,
                        ""restoreToRevision"": null,
                        ""info"": {
                          ""added"": {
                            ""strings"": 17,
                            ""words"": 43
                          },
                          ""deleted"": {
                            ""strings"": 17,
                            ""words"": 43
                          },
                          ""updated"": {
                            ""strings"": 17,
                            ""words"": 43
                          }
                        },
                        ""date"": ""2019-09-20T09:08:16+00:00""
                      }
                    }
                  ],
                  ""pagination"": {
                    ""offset"": 0,
                    ""limit"": 25
                  }
                }
            ");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            mockClient
                .Setup(client => client.SendGetRequest($"/projects/{projectId}/files/{fileId}/revisions", queryParams))
                .ReturnsAsync(new CrowdinApiResult {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = mockResponseObject
                });

            SourceFilesApiExecutor executor = new(mockClient.Object);
            var result = await executor.ListFileRevisions(projectId, fileId);

            Assert.NotNull(result);
            Assert.IsType<ResponseList<RevisionResource>>(result);
            Assert.Single(result.Data);
            Assert.Equal(17, result.Data[0].Info.Added.Strings);
        }

        [Fact]
        public async Task UpdateOrRestoreFile_FalseCondition() {
            var mockResponseObject = JObject.Parse(@"
                {
                  ""data"": {
                    ""id"": 44,
                    ""projectId"": 2,
                    ""branchId"": 34,
                    ""directoryId"": 4,
                    ""name"": ""umbrella_app.xliff"",
                    ""title"": ""source_app_info"",
                    ""type"": ""xliff"",
                    ""path"": ""/directory1/directory2/filename.extension"",
                    ""status"": ""active"",
                    ""revisionId"": 1,
                    ""priority"": ""normal"",
                    ""importOptions"": {
                      ""firstLineContainsHeader"": false,
                      ""importTranslations"": false,
                      ""scheme"": {
                        ""identifier"": 0,
                        ""sourcePhrase"": 1,
                        ""en"": 2,
                        ""de"": 3
                      }
                    },
                    ""exportOptions"": {
                      ""exportPattern"": ""/localization/%locale%/%file_name%.%file_extension%""
                    },
                    ""excludedTargetLanguages"": [
                      ""en"",
                      ""es"",
                      ""pl""
                    ],
                    ""createdAt"": ""2019-09-19T15:10:43+00:00"",
                    ""updatedAt"": ""2019-09-19T15:10:46+00:00""
                  }
                }
            ");

            var message = new HttpResponseMessage();
            var headers = message.Headers;

            var request = new ReplaceFileRequest() {
                StorageId = 1,
                UpdateOption = FileUpdateOption.ClearTranslationsAndApprovals,
                ImportOptions = new SpreadsheetFileImportOptions() {
                    FirstLineContainsHeader = true
                },
                ExportOptions = new PropertyFileExportOptions() {
                    EscapeQuotes = EscapeQuotesMode.EscapeSingleQuoteByAnotherSingleQuoteOnlyIfVariables
                }
            } as UpdateOrRestoreFileRequest;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPutRequest($"/projects/{projectId}/files/{fileId}", request))
                .ReturnsAsync(new CrowdinApiResult {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = mockResponseObject,
                    Headers = headers
                });

            SourceFilesApiExecutor executor = new(mockClient.Object);
            var result = await executor.UpdateOrRestoreFile(projectId, fileId, request);

            Assert.IsType<(File, bool?)>(result);
            Assert.NotNull(result.File);
            Assert.Equal("umbrella_app.xliff", result.File.Name);
            Assert.IsType<SpreadsheetFileImportOptions>(result.File.ImportOptions);
        }

        public async Task UpdateOrRestoreFile_TrueCondition_Helper(string headerValue) {
            var mockResponseObject = JObject.Parse(@"
                {
                  ""data"": {
                    ""id"": 44,
                    ""projectId"": 2,
                    ""branchId"": 34,
                    ""directoryId"": 4,
                    ""name"": ""umbrella_app.xliff"",
                    ""title"": ""source_app_info"",
                    ""type"": ""xliff"",
                    ""path"": ""/directory1/directory2/filename.extension"",
                    ""status"": ""active"",
                    ""revisionId"": 1,
                    ""priority"": ""normal"",
                    ""importOptions"": {
                      ""firstLineContainsHeader"": false,
                      ""importTranslations"": false,
                      ""scheme"": {
                        ""identifier"": 0,
                        ""sourcePhrase"": 1,
                        ""en"": 2,
                        ""de"": 3
                      }
                    },
                    ""exportOptions"": {
                      ""exportPattern"": ""/localization/%locale%/%file_name%.%file_extension%""
                    },
                    ""excludedTargetLanguages"": [
                      ""en"",
                      ""es"",
                      ""pl""
                    ],
                    ""createdAt"": ""2019-09-19T15:10:43+00:00"",
                    ""updatedAt"": ""2019-09-19T15:10:46+00:00""
                  }
                }
            ");

            var message = new HttpResponseMessage();
            var headers = message.Headers;
            headers.Add("Crowdin-API-Content-Status", headerValue);

            var request = new ReplaceFileRequest() {
                StorageId = 1,
                UpdateOption = FileUpdateOption.ClearTranslationsAndApprovals,
                ImportOptions = new SpreadsheetFileImportOptions() {
                    FirstLineContainsHeader = true
                }
            };

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPutRequest($"/projects/{projectId}/files/{fileId}", request))
                .ReturnsAsync(new CrowdinApiResult {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = mockResponseObject,
                    Headers = headers
                });

            SourceFilesApiExecutor executor = new(mockClient.Object);
            var result = await executor.UpdateOrRestoreFile(projectId, fileId, request);

            Assert.IsType<(File, bool?)>(result);
            Assert.NotNull(result.File);
            Assert.Equal("umbrella_app.xliff", result.File.Name);
            Assert.IsType<SpreadsheetFileImportOptions>(result.File.ImportOptions);
        }

        [Fact]
        public async Task UpdateOrRestoreFile_TrueCondition_Modified() => await UpdateOrRestoreFile_TrueCondition_Helper("modified");
        [Fact]
        public async Task UpdateOrRestoreFile_TrueCondition_NotModified() => await UpdateOrRestoreFile_TrueCondition_Helper("not-modified");
        [Fact]
        public async Task UpdateOrRestoreFile_TrueCondition_Empty() => await UpdateOrRestoreFile_TrueCondition_Helper("");
    }
}
