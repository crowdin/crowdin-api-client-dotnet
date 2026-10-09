#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;
using Crowdin.Api.ProjectsGroups;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class UserContributionVoteCount
    {
        [JsonProperty("strings")]
        public long Strings { get; set; }
    }
}
