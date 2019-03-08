using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Crowdin.Api.Protocol;

namespace Crowdin.Api
{
    public sealed class Client
    {
        public Client(HttpClient httpClient)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        private HttpClient HttpClient { get; }

        public Task<HttpResponseMessage> SendApiRequest(String url, Credentials credentials, Object body = null,
            ResponseType responseType = ResponseType.Xml, CancellationToken cancellationToken = default)
        {
            HttpRequestMessage request = new HttpRequestMessageBuilder()
                .SetUri(url)
                .SetCredentials(credentials)
                .SetBody(body)
                .SetResponseType(responseType)
                .Build();
            return SendApiRequest(request, cancellationToken);
        }

        private Task<HttpResponseMessage> SendApiRequest(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return HttpClient.SendAsync(request, cancellationToken);
        }
    }
}
