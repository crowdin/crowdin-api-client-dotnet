using System.Globalization;
using System.Resources;

namespace Crowdin.Api.UnitTesting.Resources
{
    internal class Integrations
    {
        private static readonly ResourceManager ResourceManager = new ResourceManager(
            "Crowdin.Api.UnitTesting.Resources.Integrations",
            typeof(Integrations).Assembly);

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
