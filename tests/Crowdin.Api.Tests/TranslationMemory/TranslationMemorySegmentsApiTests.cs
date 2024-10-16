
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.Tests.Testing;
using Crowdin.Api.Tests.Testing.Resources;
using Crowdin.Api.TranslationMemory;

namespace Crowdin.Api.Tests.TranslationMemory
{
    public class TranslationMemorySegmentsApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task ListTmSegments()
        {
            const int tmId = 1;
            const int limit = 10, offset = 1;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/tms/{tmId}/segments";
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging(limit, offset);

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(TranslationMemory_Segments.ListTmSegments_Response)
                });

            var executor = new TranslationMemoryApiExecutor(mockClient.Object);
            ResponseList<TmSegmentResource>? response = await executor.ListTmSegments(tmId, limit, offset);

            Assert.NotNull(response);
            Assert.Single(response.Data);
            Assert_TranslationMemorySegment(response.Data[0]);
        }

        [Fact]
        public async Task CreateTmSegment()
        {
            const int tmId = 1;

            var request = new CreateTmSegmentRequest
            {
                Records = new[]
                {
                    new TmSegmentRecordForm
                    {
                        LanguageId = "uk",
                        Text = "Перекладений текст"
                    }
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(TranslationMemory_Segments.CreateTmSegment_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/tms/{tmId}/segments";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(TranslationMemory_Segments.CommonResponses_TmSegment)
                });

            var executor = new TranslationMemoryApiExecutor(mockClient.Object);
            TmSegmentResource? response = await executor.CreateTmSegment(tmId, request);

            Assert_TranslationMemorySegment(response);
        }

        [Fact]
        public async Task GetTmSegment()
        {
            const int tmId = 1;
            const int segmentId = 4;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/tms/{tmId}/segments/{segmentId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(TranslationMemory_Segments.CommonResponses_TmSegment)
                });

            var executor = new TranslationMemoryApiExecutor(mockClient.Object);
            TmSegmentResource? response = await executor.GetTmSegment(tmId, segmentId);

            Assert_TranslationMemorySegment(response);
        }

        [Fact]
        public async Task DeleteTmSegment()
        {
            const int tmId = 1;
            const int segmentId = 2;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/tms/{tmId}/segments/{segmentId}";

            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new TranslationMemoryApiExecutor(mockClient.Object);
            await executor.DeleteTmSegment(tmId, segmentId);
        }

        [Fact]
        public async Task DeleteTmSegmentRecord()
        {
            const int tmId = 1;
            const int segmentId = 2;
            const int recordId = 3;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/tms/{tmId}/segments/{segmentId}/records/{recordId}";

            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new TranslationMemoryApiExecutor(mockClient.Object);
            await executor.DeleteTmSegmentRecord(tmId, segmentId, recordId);
        }

        [Fact]
        public async Task EditTmSegmentRecord()
        {
            const int tmId = 1;
            const int segmentId = 2;
            const int recordId = 3;

            var patches = new[]
            {
                new TmSegmentRecordPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = TmSegmentRecordPatchPath.Text,
                    Value = "new name"
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(patches, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(TranslationMemory_Segments.EditTmSegmentRecord_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/tms/{tmId}/segments/{segmentId}/records/{recordId}";

            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(TranslationMemory_Segments.CommonResponses_TmSegment)
                });

            var executor = new TranslationMemoryApiExecutor(mockClient.Object);
            TmSegmentResource? response = await executor.EditTmSegmentRecord(tmId, segmentId, recordId, patches);

            Assert_TranslationMemorySegment(response);
        }

        [Fact]
        public async Task CreateTmSegmentRecords()
        {
            const int tmId = 1;
            const int segmentId = 2;

            var request = new CreateTmSegmentRecordsRequest
            {
                Records = new[]
                {
                    new TmSegmentRecordForm
                    {
                        LanguageId = "uk",
                        Text = "Перекладений текст"
                    }
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(TranslationMemory_Segments.CreateTmSegmentRecords_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/tms/{tmId}/segments/{segmentId}/records";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(TranslationMemory_Segments.CommonResponses_TmSegment)
                });

            var executor = new TranslationMemoryApiExecutor(mockClient.Object);
            TmSegmentResource? response = await executor.CreateTmSegmentRecords(tmId, segmentId, request);

            Assert_TranslationMemorySegment(response);
        }

        private static void Assert_TranslationMemorySegment(TmSegmentResource? segment)
        {
            Assert.NotNull(segment);
            Assert.Single(segment!.Records);

            TmSegmentRecord? record = segment.Records[0];
            Assert.NotNull(record);

            Assert.Equal(1, record.Id);
            Assert.Equal("uk", record.LanguageId);
            Assert.Equal("Перекладений текст", record.Text);
            Assert.Equal(13, record.UsageCount);
            Assert.Equal(1, record.CreatedBy);
            Assert.Equal(1, record.UpdatedBy);

            DateTimeOffset date = DateTimeOffset.Parse("2019-09-16T13:48:04+00:00");
            Assert.Equal(date, record.CreatedAt);
            Assert.Equal(date, record.UpdatedAt);
        }
    }
}