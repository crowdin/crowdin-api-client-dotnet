#nullable enable

using System.Threading.Tasks;

using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.ExternalQaChecks
{
    [PublicAPI]
    public interface IExternalQaChecksApiExecutor
    {
        Task<ResponseList<ExternalQaCheck>> ListExternalQaChecks(ExternalQaChecksListParams? @params = null);

        Task<ExternalQaCheck> GetExternalQaCheck(long externalQaCheckId);
    }
}
