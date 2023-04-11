
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Core
{
    internal class CrowdinApiResult
    {
        internal HttpStatusCode StatusCode { get; set; }

        internal JObject JsonObject { get; set; }

        internal HttpResponseHeaders Headers { get; set; }
    }
}