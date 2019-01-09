using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net.Http;
using System.Web;

namespace Crowdin.Api.Protocol
{
    internal sealed class HttpRequestMessageBuilder
    {
        public HttpRequestMessageBuilder Clear()
        {
            _uri = null;
            _credentials = null;
            _body = null;
            return this;
        }

        public HttpRequestMessageBuilder SetUri(String uri)
        {
            _uri = uri;
            return this;
        }

        public HttpRequestMessageBuilder SetCredentials(Credentials credentials)
        {
            _credentials = credentials;
            return this;
        }

        public HttpRequestMessageBuilder SetBody(Object body)
        {
            _body = body;
            return this;
        }

        public HttpRequestMessage Build()
        {
            Uri uri = BuildUri();
            HttpRequestMessage requestMessage = _body == null
                ? BuildGetRequestMessage(uri)
                : BuildPostRequestMessage(uri);

            return requestMessage;
        }

        private Uri BuildUri()
        {
            String uri = _uri;
            String queryString = null;
            if (_credentials != null)
            {
                NameValueCollection query = HttpUtility.ParseQueryString(String.Empty);
                if (_credentials is AccountCredentials accountCredentials)
                {
                    query["login"] = accountCredentials.LoginName;
                    query["account-key"] = accountCredentials.AccountKey;
                }
                else
                {
                    var projectCredentials = (ProjectCredentials)_credentials;
                    query["key"] = projectCredentials.ProjectKey;
                }

                queryString = "&" + query;
            }

            return new Uri(uri + "?json=1" + queryString, UriKind.Relative);
        }

        private HttpRequestMessage BuildGetRequestMessage(Uri requestUri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            return requestMessage;
        }

        private HttpRequestMessage BuildPostRequestMessage(Uri requestUri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = BuildMultipartFormDataContent()
            };
            return requestMessage;
        }

        private MultipartFormDataContent BuildMultipartFormDataContent()
        {
            IEnumerable<(String, Object)> members = RequestBodySerializer.Serialize(_body);
            var content = new MultipartFormDataContent();
            foreach ((String name, Object value) in members)
            {
                if (value is FileInfo file)
                {
                    var partContent = new StreamContent(file.OpenRead());
                    content.Add(partContent, name, file.Name);
                }
                else
                {
                    var partContent = new StringContent(value.ToString());
                    content.Add(partContent, name);
                }
            }

            return content;
        }

        private String _uri;
        private Credentials _credentials;
        private Object _body;
    }
}
