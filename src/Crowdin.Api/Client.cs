using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Crowdin.Api.Protocol;

namespace Crowdin.Api
{
    public sealed partial class Client
    {
        public Client(HttpClient httpClient)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _errorSerializer = new XmlSerializer(typeof(Error));
        }

        private HttpClient HttpClient { get; }

        public async Task<T> SendApiRequest<T>(String url, Credentials credentials, Object body = null, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = await SendApiRequest(url, credentials, body, cancellationToken);
            T result = await ReadApiResponse<T>(response, cancellationToken);
            return result;
        }

        public Task<HttpResponseMessage> SendApiRequest(String url, Credentials credentials, Object body = null, CancellationToken cancellationToken = default)
        {
            HttpRequestMessage request = new HttpRequestMessageBuilder()
                .SetUri(url)
                .SetCredentials(credentials)
                .SetBody(body)
                .ExpectXml()
                .Build();
            return SendApiRequest(request, cancellationToken);
        }

        private Task<HttpResponseMessage> SendApiRequest(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return HttpClient.SendAsync(request, cancellationToken);
        }

        private async Task<T> ReadApiResponse<T>(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            if (response.Content.Headers.ContentType.MediaType != "text/xml")
            {
                throw new InvalidOperationException("Only XML content is acceptable.");
            }
            using (Stream xml = await response.Content.ReadAsStreamAsync())
            {
                EnsureSucess(xml);
                using (XmlReader xmlReader = XmlReader.Create(xml))
                {
                    var xmlSerializer = new XmlSerializer(typeof(T));
                    var result = (T)xmlSerializer.Deserialize(xmlReader);
                    return result;
                }
            }
        }

        private void EnsureSucess(Stream response)
        {
            using (XmlReader xmlReader = XmlReader.Create(response))
            {
                if (_errorSerializer.CanDeserialize(xmlReader))
                {
                    var error = (Error)_errorSerializer.Deserialize(xmlReader);
                    throw new CrowdinException(error.Message, error.Code);
                }
                response.Seek(0, SeekOrigin.Begin);
            }
        }

        private readonly XmlSerializer _errorSerializer;
    }
}
