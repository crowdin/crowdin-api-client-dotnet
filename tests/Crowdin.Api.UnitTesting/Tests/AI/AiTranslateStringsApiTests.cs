using System;
using System.Net;
using System.Threading.Tasks;
using Crowdin.Api.AI;
using Crowdin.Api.Core;
using Crowdin.Api.UnitTesting.Resources;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.UnitTesting.Tests.AI;

public class AiTranslateStringsApiTests
{
    private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

    [Fact]
    public async Task TranslateStrings()
    {
        const int userId = 1;

        var request = new AiTranslateStringsRequest
        {
            Strings = new[] { "Some text to translate!" },
            TargetLanguageId = "uk",
            SourceLanguageId = "en",
            TmIds = new[] { 123 },
            GlossaryIds = new[] { 456 },
            AiPromptId = 789,
            Instructions = new[] { "Keep a formal tone" },
            AttachmentIds = new[] { 123 }
        };

        string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
        string expectedRequestJson = TestUtils.CompactJson(AI_TranslateStrings.TranslateStrings_Request);
        Assert.Equal(expectedRequestJson, actualRequestJson);

        Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

        var url = $"/users/{userId}/ai/translate";

        mockClient
            .Setup(client => client.SendPostRequest(url, request, null))
            .ReturnsAsync(new CrowdinApiResult
            {
                StatusCode = HttpStatusCode.OK,
                JsonObject = JObject.Parse(AI_TranslateStrings.CommonResponses_TranslateStrings)
            });

        var executor = new AiApiExecutor(mockClient.Object);
        AiTranslateStringsResponse response = await executor.TranslateStrings(userId, request);

        Assert_TranslateStrings(response);
    }

    private static void Assert_TranslateStrings(AiTranslateStringsResponse? response)
    {
        ArgumentNullException.ThrowIfNull(response);

        Assert.Equal("en", response.SourceLanguageId);
        Assert.Equal("uk", response.TargetLanguageId);
        Assert.NotNull(response.Translations);
        Assert.Equal(2, response.Translations.Count);
    }
}