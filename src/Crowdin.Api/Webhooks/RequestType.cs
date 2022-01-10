
using Crowdin.Api.Core.Converters;
using JetBrains.Annotations;

namespace Crowdin.Api.Webhooks
{
    [PublicAPI]
    [StrictStringRepresentation]
    public enum RequestType
    {
        // ReSharper disable InconsistentNaming
        GET,
        
        POST
        // ReSharper restore InconsistentNaming
    }
}