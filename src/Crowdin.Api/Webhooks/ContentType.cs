
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Webhooks
{
    [PublicAPI]
    public enum ContentType
    {
        [Description("multipart/form-data")]
        MultipartFormData,
        
        [Description("application/json")]
        ApplicationJson,
        
        [Description("application/x-www-form-urlencoded")]
        ApplicationFormUrlencoded
    }
}