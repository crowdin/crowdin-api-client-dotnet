using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xunit;

using Crowdin.Api.Core;

namespace Crowdin.Api.UnitTesting.Tests
{
    public class CrowdinApiClientDeleteTests
    {
        [Fact]
        public async Task SendDeleteRequest_FullResult_AddsExtraHeaders()
        {
            var handler = new RecordingHandler();
            using var httpClient = new HttpClient(handler);
            var client = new CrowdinApiClient(
                new CrowdinCredentials
                {
                    AccessToken = "token",
                    BaseUrl = "https://example.com/api/v2"
                },
                httpClient);

            IDictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Prefer", "respond-async" }
            };

            CrowdinApiResult result = await ((ICrowdinApiClient)client)
                .SendDeleteRequest_FullResult("/projects/1/files/2", null, headers);

            Assert.Equal(HttpStatusCode.Accepted, result.StatusCode);
            Assert.NotNull(handler.Request);
            Assert.Equal("respond-async", handler.Request!.Headers.GetValues("Prefer").Single());
        }

        private sealed class RecordingHandler : HttpMessageHandler
        {
            public HttpRequestMessage? Request { get; private set; }

            protected override Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request,
                CancellationToken cancellationToken)
            {
                Request = request;
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent("{}", Encoding.UTF8, "application/json")
                });
            }
        }
    }
}