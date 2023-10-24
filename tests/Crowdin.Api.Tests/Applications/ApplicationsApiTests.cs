using System.Net;
using System.Threading.Tasks;
using Crowdin.Api.Applications;
using Crowdin.Api.Core;
using Crowdin.Api.Tests.Core;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.Tests.Applications
{
    public class ApplicationsApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();
        private const string applicationIdentifier = "some_application";
        private const string path = "/configure";
        private const string url = $"/applications/{applicationIdentifier}/api/{path}";

        [Fact]
        public async Task GetApplicationData()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient.Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Applications.GetApplicationData_Response)
                });
            var executor = new ApplicationsApiExecutor(mockClient.Object);
            var response = await executor.GetApplicationData(applicationIdentifier, path);

            Assert.NotNull(response);

            IJsonParser jsonParser = mockClient.Object.DefaultJsonParser;
            var data = jsonParser.ParseResponseObject<ApplicationDataTestResource>(response);
            Assert.NotNull(data);
            Assert.Equal("some_application", data.Identifier);
            Assert.Equal("https://video-preview.awesome-crowdin.com", data.BaseUrl);
            Assert.Equal("/logo.png", data.Logo);
        }

        [Fact]
        public async Task DeleteApplicationData()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient.Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new ApplicationsApiExecutor(mockClient.Object);
            await executor.DeleteApplicationData(applicationIdentifier, path);
        }
    }

    public class ApplicationDataTestResource
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string BaseUrl { get; set; }
        public string[] Scopes { get; set; }
    }
}