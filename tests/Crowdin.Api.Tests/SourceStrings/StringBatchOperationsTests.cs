
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.SourceStrings;
using Crowdin.Api.Tests.Core;

namespace Crowdin.Api.Tests.SourceStrings
{
    public class StringBatchOperationsTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();
        
        [Fact]
        public async Task StringBatchOperations()
        {
            const int projectId = 1;
            const int stringId1 = 2814;
            const int stringId2 = 2815;

            var patches = new[]
            {
                new StringBatchOpPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = new StringBatchOpPatchPath
                    {
                        StringId = stringId1,
                        Property = StringBatchOpPatchPathEntry.IsHidden
                    },
                    Value = true
                },
                new StringBatchOpPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = new StringBatchOpPatchPath
                    {
                        StringId = stringId1,
                        Property = StringBatchOpPatchPathEntry.Context
                    },
                    Value = "some context"
                },
                new StringBatchOpPatch
                {
                    Operation = PatchOperation.Add,
                    Path = new StringBatchOpPatchPath
                    {
                        StringId = null,
                        Property = null
                    },
                    Value = new AddStringRequest
                    {
                        Text = "new added string",
                        Identifier = "a.b.c",
                        Context = "context for new string",
                        FileId = 5,
                        IsHidden = false
                    }
                },
                new StringBatchOpPatch
                {
                    Operation = PatchOperation.Remove,
                    Path = new StringBatchOpPatchPath
                    {
                        StringId = stringId2
                    }
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(patches, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.SourceStrings.StringBatchOperations_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/strings";

            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.SourceStrings.CommonResponses_SingleStringInArray)
                });

            var executor = new SourceStringsApiExecutor(mockClient.Object);
            ResponseList<SourceString> response = await executor.StringBatchOperations(projectId, patches);
            
            Assert.NotNull(response);
            Assert_SourceString(response.Data?.Single());
        }

        private static void Assert_SourceString(SourceString? sourceString)
        {
            Assert.NotNull(sourceString);
            
            Assert.Equal(2814, sourceString!.Id);
            Assert.Equal(2, sourceString.ProjectId);
            Assert.Equal(48, sourceString.FileId);
            Assert.Equal(12, sourceString.BranchId);
            Assert.Equal(13, sourceString.DirectoryId);
            Assert.Equal("name", sourceString.Identifier);
            Assert.Equal("Not all videos are shown to users. See more", sourceString.Text);
            Assert.Equal("text", sourceString.Type);
            Assert.Equal("shown on main page", sourceString.Context);
            Assert.Equal(35, sourceString.MaxLength);
            Assert.Equal(1, sourceString.MasterStringId);
            Assert.Equal(1, sourceString.Revision);
            Assert.Equal(3, sourceString.LabelIds?.Single());
            Assert.Equal(DateTimeOffset.Parse("2019-09-20T12:43:57+00:00"), sourceString.CreatedAt);
            Assert.Equal(DateTimeOffset.Parse("2019-09-20T13:24:01+00:00"), sourceString.UpdatedAt);

            Assert.True(sourceString.IsDuplicate);
            Assert.False(sourceString.IsHidden);
            Assert.False(sourceString.HasPlurals);
            Assert.False(sourceString.IsIcu);
        }
    }
}