
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api
{
    [PublicAPI]
    public class TranslatorRolePermissions
    {
        [JsonProperty("allLanguages")]
        public bool? AllLanguages { get; set; }
        
        [JsonProperty("languagesAccess")]
        public object? LanguagesAccess { get; set; }
    }
}