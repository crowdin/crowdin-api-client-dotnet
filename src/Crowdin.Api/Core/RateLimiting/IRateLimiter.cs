
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Crowdin.Api.Core.RateLimiting
{
    public interface IRateLimiter
    {
        Task<HttpResponseMessage> ExecuteRequest(Func<int, Task<HttpResponseMessage>> runRequest);
    }
}