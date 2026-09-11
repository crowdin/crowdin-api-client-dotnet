
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

#nullable enable

namespace Crowdin.Api.Applications
{
    [PublicAPI]
    public interface IApplicationsApiExecutor
    {
        Task<ResponseList<ApplicationConsent>> ListApplicationConsents(
            string? identifier = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ApplicationConsent> AddApplicationConsent(AddApplicationConsentRequest request);

        Task<ApplicationConsent> EditApplicationConsent(
            long consentId,
            IEnumerable<ApplicationConsentPatch> patches);

        Task DeleteApplicationConsent(long consentId);

        Task<ResponseList<Application>> ListApplicationInstallations(int limit = 25, int offset = 0);

        Task<Application> GetApplicationInstallation(string applicationIdentifier);

        Task<Application> InstallApplication(InstallApplicationRequest request);

        Task DeleteApplicationInstallation(string applicationIdentifier, bool force = false);

        Task<Application> EditApplicationInstallation(
            string applicationIdentifier,
            IEnumerable<InstallationPatch> patches);

        Task<JObject> GetApplicationData(string applicationIdentifier, string path);

        Task<JObject> UpdateOrRestoreApplicationData(string applicationIdentifier, string path, object request);

        Task<JObject> AddApplicationData(string applicationIdentifier, string path, object request);

        Task DeleteApplicationData(string applicationIdentifier, string path);

        Task<JObject> EditApplicationData(string applicationIdentifier, string path, object patches);
    }
}
