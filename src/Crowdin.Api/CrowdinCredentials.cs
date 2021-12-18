
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api
{
    [PublicAPI]
    public class CrowdinCredentials
    {
#pragma warning disable CS8618
        public string AccessToken { get; set; }
#pragma warning restore CS8618
        
        public string? Organization { get; set; }
        
        public string? BaseUrl { get; set; }
    }
}