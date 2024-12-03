
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

using Crowdin.Api.Applications;

namespace Crowdin.Api.Abstractions
{
    [PublicAPI]
    public interface IApplicationsApiExecutor
    {
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