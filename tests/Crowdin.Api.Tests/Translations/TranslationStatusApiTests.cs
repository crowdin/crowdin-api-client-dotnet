
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.Tests.Testing;
using Crowdin.Api.TranslationStatus;
using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.Tests.Translations
{
    public class TranslationStatusApiTests
    {
        [Fact]
        public async Task GetLanguageProgress()
        {
            const int projectId = 1;
            const string languageId = "es";

            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            var mockClient = new Mock<ICrowdinApiClient>();
            mockClient
                .Setup(client => client.SendGetRequest(
                    $"/projects/{projectId}/languages/{languageId}/progress", queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Testing.Resources.Translations.GetLanguageStatusResponse)
                });

            var executor = new TranslationStatusApiExecutor(mockClient.Object, TestUtils.CreateJsonParser());

            ResponseList<LanguageProgressResource> response = await executor.GetLanguageProgress(projectId, languageId);
            Assert.NotNull(response);
        }
    }
}
