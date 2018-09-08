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
