
namespace Crowdin.Api.Samples.Actions
{
    public partial class CrowdinActions
    {
        private readonly ICrowdinApiClient _crowdinApiClient;

        public CrowdinActions(string accessToken)
        {
            _crowdinApiClient = new CrowdinApiClient(new CrowdinCredentials 
            {
                AccessToken = accessToken
            });
        }
    }
}