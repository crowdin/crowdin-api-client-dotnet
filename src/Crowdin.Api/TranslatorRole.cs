
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api
{
    [PublicAPI]
    public class TranslatorRole
    {
        [JsonProperty("name")]
        public TranslatorRoleName? Name { get; set; }
        
        [JsonProperty("permissions")]
        public TranslatorRolePermissions? Permissions { get; set; }
    }
}