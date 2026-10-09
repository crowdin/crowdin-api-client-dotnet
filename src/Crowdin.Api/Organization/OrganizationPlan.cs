#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Organization
{
    [PublicAPI]
    public class OrganizationPlan
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("wordsLimit")]
        public long? WordsLimit { get; set; }

        [JsonProperty("managersLimit")]
        public long? ManagersLimit { get; set; }
    }
}
