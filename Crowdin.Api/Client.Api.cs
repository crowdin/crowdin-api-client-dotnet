using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Crowdin.Api
{
    partial class Client
    {
        public Task<HttpResponseMessage> GetSupportedLanguages(CancellationToken cancellationToken = default)
        {
            return SendApiRequest("supported-languages", (AccountCredentials)null, null, cancellationToken);
        }

        public Task<HttpResponseMessage> GetAccountProjects(AccountCredentials credentials, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("account/get-projects", credentials, null, cancellationToken);
        }
    }
}
