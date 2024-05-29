
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Webhooks
{
    [PublicAPI]
    public enum ContentType
    {
        [SerializedValue("multipart/form-data")]
        MultipartFormData,
        
        [SerializedValue("application/json")]
        ApplicationJson,
        
        [SerializedValue("application/x-www-form-urlencoded")]
        ApplicationFormUrlencoded
    }
}