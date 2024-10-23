
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.Glossaries;
using Crowdin.Api.UnitTesting.Resources;

namespace Crowdin.Api.UnitTesting.Tests.Glossaries
{
    public class ConceptsApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task ListConcepts()
        {
            const int glossaryId = 6;

            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            queryParams.Add("orderBy", "createdAt desc");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/glossaries/{glossaryId}/concepts";

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Glossaries_Concepts.ListConcepts_Response)
                });

            var executor = new GlossariesApiExecutor(mockClient.Object);
            ResponseList<Concept> response = await executor.ListConcepts(
                glossaryId,
                orderBy: new[]
                {
                    new SortingRule
                    {
                        Field = "createdAt",
                        Order = SortingOrder.Descending
                    }
                });

            Assert.NotNull(response);
            Assert.Single(response.Data);
            Assert.Equal(glossaryId, response.Data[0].GlossaryId);
        }

        [Fact]
        public async Task GetConcept()
        {
            const int glossaryId = 6;
            const int conceptId = 2;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/glossaries/{glossaryId}/concepts/{conceptId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Glossaries_Concepts.GetConcept_Response)
                });

            var executor = new GlossariesApiExecutor(mockClient.Object);
            Concept response = await executor.GetConcept(glossaryId, conceptId);

            Assert.NotNull(response);
            Assert.Equal(conceptId, response.Id);
            Assert.Equal(glossaryId, response.GlossaryId);

            Assert.NotNull(response.LanguagesDetails);
            Assert.Single(response.LanguagesDetails);
            Assert.Equal(DateTimeOffset.Parse("2019-09-19T14:14:00+00:00"), response.LanguagesDetails[0].CreatedAt);
        }

        [Fact]
        public async Task UpdateConcept()
        {
            const int glossaryId = 6;
            const int conceptId = 2;

            var request = new UpdateConceptRequest
            {
                Subject = "general",
                Definition = "This is a sample definition.",
                Note = "Any concept-level note information",
                Url = "string",
                Figure = "string",
                LanguagesDetails = new[]
                {
                    new ConceptLanguageDetailsForm
                    {
                        LanguageId = "en",
                        Definition = "This is a sample definition.",
                        Note = "Any kind of note, such as a usage note, explanation, or instruction."
                    }
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Glossaries_Concepts.UpdateConcept_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/glossaries/{glossaryId}/concepts/{conceptId}";

            mockClient
                .Setup(client => client.SendPutRequest(url, request))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Glossaries_Concepts.UpdateConcept_Response)
                });

            var executor = new GlossariesApiExecutor(mockClient.Object);
            Concept response = await executor.UpdateConcept(glossaryId, conceptId, request);

            Assert.NotNull(response);
        }
    }
}