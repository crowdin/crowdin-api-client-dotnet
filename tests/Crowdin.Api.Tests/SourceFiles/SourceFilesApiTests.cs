
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
    public class SourceFilesApiTests
    {
        [Fact]
        public async Task EditFile()
        {
            const int projectId = 1;
            const int fileId = 2;
            const int directoryId = 3;

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
            string rightRequestJson = Core.Resources.SourceFiles.EditFile_Request;
            Assert.Equal(rightRequestJson, requestJson);
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client
                    .SendPatchRequest($"/projects/{projectId}/files/{fileId}", patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.SourceFiles.EditFile_Response)
                });

            var executor = new SourceFilesApiExecutor(mockClient.Object);

            File fileResponse = await executor.EditFile(projectId, fileId, patches);
            
            Assert.NotNull(fileResponse);
            Assert.IsType<GeneralFileExportOptions>(fileResponse.ExportOptions);
            Assert.IsType<SpreadsheetFileImportOptions>(fileResponse.ImportOptions);
        }
    }
}