using System.Globalization;
using System.Resources;

namespace Crowdin.Api.UnitTesting.Resources
{
    internal class ExternalQaChecks
    {
        private static readonly ResourceManager ResourceManager = new ResourceManager(
            "Crowdin.Api.UnitTesting.Resources.ExternalQaChecks",
            typeof(ExternalQaChecks).Assembly);

        internal static string ApiResponses
        {
            get { return ResourceManager.GetString("ApiResponses", CultureInfo.CurrentUICulture)!; }
        }

        internal static string ApiRequests
        {
            get { return ResourceManager.GetString("ApiRequests", CultureInfo.CurrentUICulture)!; }
        }
    }
}
