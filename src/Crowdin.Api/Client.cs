using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api
{
    public sealed partial class Client
    {
        public Client(HttpClient httpClient)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        private HttpClient HttpClient { get; }

        public async Task<T> SendApiRequest<T>(String url, AccountCredentials credentials,
            Object body = null,
            String payloadProperty = null,
            CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = await SendApiRequest(url, credentials, body, cancellationToken);
            T result = await ReadApiResponse<T>(response, payloadProperty, cancellationToken);
            return result;
        }

        public async Task<T> SendApiRequest<T>(String url, ProjectCredentials credentials,
            Object body = null,
            String payloadProperty = null,
            CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = await SendApiRequest(url, credentials, body, cancellationToken);
            T result = await ReadApiResponse<T>(response, payloadProperty, cancellationToken);
            return result;
        }

        public Task<HttpResponseMessage> SendApiRequest(String url, AccountCredentials credentials,
            Object body = null,
            CancellationToken cancellationToken = default)
        {
            HttpRequestMessage request = new HttpRequestMessageBuilder()
                .SetUri(url)
                .SetCredentials(credentials)
                .SetBody(body)
                .Build();
            return SendApiRequest(request, cancellationToken);
        }

        public Task<HttpResponseMessage> SendApiRequest(String url, ProjectCredentials credentials,
            Object body = null,
            CancellationToken cancellationToken = default)
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

        private async Task<T> ReadApiResponse<T>(HttpResponseMessage response, String payloadProperty, CancellationToken cancellationToken)
        {
            if (response.Content.Headers.ContentType.MediaType != "application/json")
            {
                throw new InvalidOperationException("Only JSON content is acceptable.");
            }
            String json = await response.Content.ReadAsStringAsync();
            JToken jToken = await ParseJsonAsync(json, cancellationToken);
            JToken payloadToken = GetPayloadToken(jToken, payloadProperty);

            return payloadToken.ToObject<T>();
        }

        private async Task<JToken> ParseJsonAsync(String json, CancellationToken cancellationToken)
        {
            using (var textReader = new StringReader(json))
            {
                using (var jsonReader = new JsonTextReader(textReader))
                {
                    JToken jToken = await JToken.LoadAsync(jsonReader, cancellationToken);
                    return jToken;
                }
            }
        }

        private JToken GetPayloadToken(JToken response, String payloadProperty)
        {
            EnsureSuccess(response);
            if (String.IsNullOrEmpty(payloadProperty))
            {
                return response;
            }

            if (response is JObject jObject && jObject.ContainsKey(payloadProperty))
            {
                return jObject[payloadProperty];
            }

            throw new ArgumentException($"Response object does not contain '{payloadProperty}' property.", nameof(response));
        }

        private void EnsureSuccess(JToken response)
        {
            if (!(response is JObject jObject))
            {
                return;
            }

            JProperty successProperty = jObject.Property("success");
            if (successProperty?.Value is JValue jValue && jValue.Type == JTokenType.Boolean && !(Boolean)jValue.Value)
            {
                JProperty errorProperty = jObject.Property("error");
                if (errorProperty?.Value is JObject errorObject)
                {
                    Error error = errorObject.ToObject<Error>();
                    throw new CrowdinException(error.Message, error.Code);
                }
            }
        }
    }
}
