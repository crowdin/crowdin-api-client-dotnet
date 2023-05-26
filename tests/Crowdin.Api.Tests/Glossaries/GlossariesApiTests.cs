
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.Glossaries;
using Crowdin.Api.Tests.Core;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.Tests.Glossaries
{
    public class GlossariesApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();
        
        [Fact]
        public async Task ListGlossaries()
        {
            const int groupId = 2;

            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            queryParams.Add("groupId", groupId.ToString());

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendGetRequest("/glossaries", queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Glossaries.ListGlossaries_Response)
                });

            var executor = new GlossariesApiExecutor(mockClient.Object);
            ResponseList<Glossary> response = await executor.ListGlossaries(groupId: groupId);
            
            Assert.NotNull(response);
            Assert.Single(response.Data);
            Assert.Equal(groupId, response.Data[0].GroupId);
            Assert.Equal(2, response.Data[0].DefaultProjectIds?.Single());
        }

        [Fact]
        public async Task EditGlossary()
        {
            const int glossaryId = 2;
            const string newName = "Be My Eyes iOS's Glossary";
            const string newLanguageId = "fr";

            var patches = new[]
            {
                new GlossaryPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = GlossaryPatchPath.Name,
                    Value = newName
                },
                new GlossaryPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = GlossaryPatchPath.LanguageId,
                    Value = newLanguageId
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(patches, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.Glossaries.EditGlossary_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            var url = $"/glossaries/{glossaryId}";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Glossaries.EditGlossary_Response)
                });

            var executor = new GlossariesApiExecutor(mockClient.Object);
            Glossary response = await executor.EditGlossary(glossaryId, patches);
            
            Assert.NotNull(response);
            Assert.Equal(newName, response.Name);
            Assert.Equal(newLanguageId, response.LanguageId);
        }

        [Fact]
        public async Task ConcordanceSearch()
        {
            const int projectId = 1;

            var request = new ConcordanceSearchRequest
            {
                SourceLanguageId = "en",
                TargetLanguageId = "de",
                Expression = "Welcome!"
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.Glossaries.ConcordanceSearch_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/glossaries/concordance";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Glossaries.ConcordanceSearch_Response)
                });

            var executor = new GlossariesApiExecutor(mockClient.Object);
            ResponseList<GlossaryConcordanceResultResource> response = await executor.ConcordanceSearch(projectId, request);
            
            Assert.NotNull(response);

            GlossaryConcordanceResultResource? resource = response.Data?.Single();
            Assert.NotNull(resource);

            Glossary? glossary = resource!.Glossary;
            Assert.NotNull(glossary);
            Assert.Equal(2, glossary.Id);
            Assert.Equal("fr", glossary.LanguageId);
            Assert.Equal("ro", glossary.LanguageIds.Single());
            Assert.Equal(6, glossary.ProjectIds.Single());
            Assert.Equal(DateTimeOffset.Parse("2019-09-16T13:42:04+00:00"), glossary.CreatedAt);

            Concept? concept = resource.Concept;
            Assert.NotNull(concept);
            Assert.Equal(2, concept.Id);
            Assert.Equal("general", concept.Subject);
            
            ConceptLanguageDetails? languagesDetails = concept.LanguagesDetails?.Single();
            Assert.NotNull(languagesDetails);
            Assert.Equal("en", languagesDetails!.LanguageId);
            Assert.Equal(DateTimeOffset.Parse("2019-09-19T14:14:00+00:00"), languagesDetails.CreatedAt);
            Assert.Equal(DateTimeOffset.Parse("2019-09-19T14:14:00+00:00"), languagesDetails.UpdatedAt);
            
            Assert.Equal(DateTimeOffset.Parse("2019-09-23T07:19:47+00:00"), concept.CreatedAt);
            Assert.Equal(DateTimeOffset.Parse("2019-09-23T07:19:47+00:00"), concept.CreatedAt);
            
            Assert_Term(resource.SourceTerms?.Single());
            Assert_Term(resource.TargetTerms?.Single());
        }

        private static void Assert_Term(Term? term)
        {
            Assert.NotNull(term);
            Assert.Equal(2, term!.Id);
            Assert.Equal("fr", term.LanguageId);
            Assert.Equal(PartOfSpeech.Verb, term.PartOfSpeech);
            Assert.Equal(TermStatus.Preferred, term.Status);
            Assert.Equal(TermType.Abbreviation, term.Type);
            Assert.Equal(TermGender.Masculine, term.Gender);
            Assert.Equal(DateTimeOffset.Parse("2019-09-23T07:19:47+00:00"), term.CreatedAt);
            Assert.Equal(DateTimeOffset.Parse("2019-09-23T07:19:47+00:00"), term.UpdatedAt);
        }
    }
}