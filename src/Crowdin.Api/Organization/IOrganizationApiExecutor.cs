#nullable enable

using System.Threading.Tasks;

using JetBrains.Annotations;

namespace Crowdin.Api.Organization
{
    [PublicAPI]
    public interface IOrganizationApiExecutor
    {
        Task<OrganizationInfo> GetOrganizationInfo();

        Task<OrganizationAuthSettings> GetOrganizationAuthSettings();
    }
}
