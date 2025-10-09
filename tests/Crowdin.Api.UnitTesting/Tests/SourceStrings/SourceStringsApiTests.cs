
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.SourceFiles;
using Crowdin.Api.SourceStrings;

namespace Crowdin.Api.UnitTesting.Tests.SourceStrings
{
    public class SourceStringsApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();
        
        [Fact]
        public async Task ListStrings_StringText()
        {
            const int projectId = 1;
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/projects/{projectId}/strings";

            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            
            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.SourceStrings.ListStrings_StringText)
                });
            
            var executor = new SourceStringsApiExecutor(mockClient.Object);
            
            ResponseList<SourceString> response = await executor.ListStrings(projectId);
            
            var text = response.Data.First().Text as string;
            ArgumentException.ThrowIfNullOrWhiteSpace(text);
            
            Assert.Equal("Not all videos are shown to users. See more", text);
        }

        [Fact]
        public async Task ListStrings_i18Next_PluralStrings()
        {
            const int projectId = 1;
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/projects/{projectId}/strings";

            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.SourceStrings.ListStrings_i18Next_bug)
                });
            
            var executor = new SourceStringsApiExecutor(mockClient.Object);

            ResponseList<SourceString> response = await executor.ListStrings(projectId);

            var textForms = response.Data.First().Text as SourceTextForms;
            ArgumentNullException.ThrowIfNull(textForms);
            
            Assert.Equal("{{count}} day", textForms.One);
            Assert.Equal("{{count}} days", textForms.Other);
            Assert.Null(textForms.Two);
            Assert.Null(textForms.Few);
            Assert.Null(textForms.Many);
        }

        [Fact]
        public void ListStrings_QueryStringConstruction()
        {
            const string expectedQueryString = "limit=25&offset=0&scope=context";

            var @params = new StringsListParams
            {
                Scope = StringScope.Context
            };

            Assert.Equal(expectedQueryString, @params.ToQueryParams().ToQueryString());
        }

        [Fact]
        public async Task UploadStringsStatus()
        {
            const int projectId = 1;
            const string uploadId = "50fb3506-4127-4ba8-8296-f97dc7e3e0c3";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/strings/uploads/{uploadId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.SourceStrings.CommonResponses_UploadStrings)
                });

            var executor = new SourceStringsApiExecutor(mockClient.Object);
            StringUploadResponseModel response = await executor.UploadStringsStatus(projectId, uploadId);

            Assert_StringUploadResponseModel(response);
        }

        [Fact]
        public async Task UploadStrings()
        {
            const int projectId = 1;

            var request = new UploadStringsRequest
            {
                StorageId = 61,
                BranchId = 34,
                Type = StringBasedProjectFileType.Xliff,
                ParserVersion = 1,
                LabelIds = [1, 2, 3],
                UpdateStrings = true,
                CleanupMode = true,
                ImportOptions = new SpreadsheetFileImportOptions
                {
                    FirstLineContainsHeader = false,
                    ImportTranslations = true,
                    Scheme = new Dictionary<string, int>
                    {
                        [ColumnType.Identifier] = 0,
                        [ColumnType.SourcePhrase] = 1,
                        ["en"] = 2,
                        ["de"] = 3
                    }
                },
                UpdateOption = UpdateOption.KeepTranslationsAndApprovals
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Resources.SourceStrings.UploadStrings_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/strings/uploads";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.SourceStrings.CommonResponses_UploadStrings)
                });

            var executor = new SourceStringsApiExecutor(mockClient.Object);
            StringUploadResponseModel response = await executor.UploadStrings(projectId, request);

            Assert_StringUploadResponseModel(response);
        }

        private static void Assert_StringUploadResponseModel(StringUploadResponseModel? response)
        {
            Assert.NotNull(response);
            ArgumentNullException.ThrowIfNull(response);

            Assert.Equal("50fb3506-4127-4ba8-8296-f97dc7e3e0c3", response.Identifier);
            Assert.Equal(OperationStatus.Finished, response.Status);
            Assert.Equal(100, response.Progress);

            DateTimeOffset date = DateTimeOffset.Parse("2019-09-23T11:26:54+00:00");
            Assert.Equal(date, response.CreatedAt);
            Assert.Equal(date, response.UpdatedAt);
            Assert.Equal(date, response.StartedAt);
            Assert.Equal(date, response.FinishedAt);

            StringUploadResponseModel.AttributesData? attributes = response.Attributes;
            Assert.NotNull(attributes);

            Assert.Equal(38, attributes.BranchId);
            Assert.Equal(38, attributes.StorageId);
            Assert.Equal("android", attributes.FileType);
            Assert.Equal(8, attributes.ParserVersion);
            Assert.Equal([1, 2], attributes.LabelIds);
            Assert.False(attributes.UpdateStrings);
            Assert.False(attributes.CleanupMode);
            Assert.Equal(UpdateOption.KeepTranslationsAndApprovals, attributes.UpdateOption);

            SpreadsheetFileImportOptions? importOptions = attributes.ImportOptions;
            Assert.NotNull(importOptions);

            Assert.False(importOptions.FirstLineContainsHeader);
            Assert.True(importOptions.ImportTranslations);
            Assert.Equal(new Dictionary<string, int>
            {
                [ColumnType.Identifier] = 0,
                [ColumnType.SourcePhrase] = 1,
                ["en"] = 2,
                ["de"] = 3
            }, importOptions.Scheme);
        }
    }
}