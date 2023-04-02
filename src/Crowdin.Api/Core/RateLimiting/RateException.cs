
namespace Crowdin.Api.Core.RateLimiting
{
    public class RateException : CrowdinApiException
    {
        public RateException(string message) : base(429, message) { }
    }
}