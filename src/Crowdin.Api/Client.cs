using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Crowdin.Api
{
    public sealed partial class Client : IDisposable
    {
        public Client(Uri baseAddress) : this(new HttpClient {BaseAddress = baseAddress})
        { }

        public Client(HttpClient httpClient)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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

        ~Client()
        {
            Dispose(false);
        }

        private void Dispose(Boolean disposing)
        {
            if (disposing)
            {
                HttpClient.Dispose();
            }
        }
    }
}
