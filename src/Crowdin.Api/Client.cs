using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Crowdin.Api
{
    public sealed partial class Client
    {
        public Client(HttpClient httpClient)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        private HttpClient HttpClient { get; }

        public Task<HttpResponseMessage> SendApiRequest(String url, AccountCredentials credentials, Object body, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = new HttpRequestMessageBuilder()
                .SetUri(url)
                .SetCredentials(credentials)
                .SetBody(body)
                .Build();
            return SendApiRequest(request, cancellationToken);
        }

        public Task<HttpResponseMessage> SendApiRequest(String url, ProjectCredentials credentials, Object body, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = new HttpRequestMessageBuilder()
                .SetUri(url)
                .SetCredentials(credentials)
                .SetBody(body)
                .Build();
            return SendApiRequest(request, cancellationToken);
        }

        private Task<HttpResponseMessage> SendApiRequest(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return HttpClient.SendAsync(request, cancellationToken);
        }
    }
}
