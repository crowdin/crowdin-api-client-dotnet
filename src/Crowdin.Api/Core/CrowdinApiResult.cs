
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Core
{
    public class CrowdinApiResult
    {
        public HttpStatusCode StatusCode { get; set; }

        public JObject JsonObject { get; set; }

        public HttpResponseHeaders Headers { get; set; }
    }
}