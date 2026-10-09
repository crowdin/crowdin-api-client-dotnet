#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;
using Crowdin.Api.ProjectsGroups;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class UserContributionCount
    {
        [JsonProperty("strings")]
        public long Strings { get; set; }

        [JsonProperty("words")]
        public long Words { get; set; }
    }
}
