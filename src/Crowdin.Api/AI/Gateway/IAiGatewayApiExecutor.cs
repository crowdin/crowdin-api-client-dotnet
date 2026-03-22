
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.AI.Gateway
{
    [PublicAPI]
    public interface IAiGatewayApiExecutor
    {
        /// <summary>
        /// AI Gateway GET. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/AI-Gateway/operation/api.ai.providers.gateway.crowdin.get">Crowdin File Based API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/AI-Gateway/operation/api.ai.providers.gateway.crowdin.get">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/AI-Gateway/operation/api.ai.providers.gateway.enterprise.get">Crowdin Enterprise API</a>
        /// </summary>
        Task<JObject> ExecuteGet(long? userId, long aiProviderId, string path);

        /// <summary>
        /// AI Gateway POST. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/AI-Gateway/operation/api.ai.providers.gateway.crowdin.post">Crowdin File Based API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/AI-Gateway/operation/api.ai.providers.gateway.crowdin.post">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/AI-Gateway/operation/api.ai.providers.gateway.enterprise.post">Crowdin Enterprise API</a>
        /// </summary>
        Task<JObject> ExecutePost(long? userId, long aiProviderId, string path, object request);

        /// <summary>
        /// AI Gateway PUT. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/AI-Gateway/operation/api.ai.providers.gateway.crowdin.put">Crowdin File Based API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/AI-Gateway/operation/api.ai.providers.gateway.crowdin.put">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/AI-Gateway/operation/api.ai.providers.gateway.enterprise.put">Crowdin Enterprise API</a>
        /// </summary>
        Task<JObject> ExecutePut(long? userId, long aiProviderId, string path, object request);

        /// <summary>
        /// AI Gateway DELETE. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/AI-Gateway/operation/api.ai.providers.gateway.crowdin.delete">Crowdin File Based API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/AI-Gateway/operation/api.ai.providers.gateway.crowdin.delete">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/AI-Gateway/operation/api.ai.providers.gateway.enterprise.delete">Crowdin Enterprise API</a>
        /// </summary>
        Task<JObject> ExecuteDelete(long? userId, long aiProviderId, string path);

        /// <summary>
        /// AI Gateway PATCH. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/AI-Gateway/operation/api.ai.providers.gateway.crowdin.patch">Crowdin File Based API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/AI-Gateway/operation/api.ai.providers.gateway.crowdin.patch">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/AI-Gateway/operation/api.ai.providers.gateway.enterprise.patch">Crowdin Enterprise API</a>
        /// </summary>
        Task<JObject> ExecutePatch(long? userId, long aiProviderId, string path, object request);
    }
}