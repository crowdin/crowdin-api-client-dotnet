
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api
{
    public interface ICrowdinApiClient
    {
        IJsonParser DefaultJsonParser { get; }
        
        Task<CrowdinApiResult> SendGetRequest(string subUrl, IDictionary<string, string>? queryParams = null);

        Task<CrowdinApiResult> SendPostRequest(string subUrl, object body, IDictionary<string, string>? extraHeaders = null);

        Task<CrowdinApiResult> SendPutRequest(string subUrl, object body);

        Task<CrowdinApiResult> SendPatchRequest(string subUrl, IEnumerable<PatchEntry> body);

        Task<HttpStatusCode> SendDeleteRequest(string subUrl);

        Task<CrowdinApiResult> UploadFile(string subUrl, string filename, Stream fileStream);
    }
}