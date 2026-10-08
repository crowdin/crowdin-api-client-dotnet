#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;
using Crowdin.Api.ProjectsGroups;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class UserProjectContribution
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("translated")]
        public UserContributionCount Translated { get; set; } = null!;

        [JsonProperty("approved")]
        public UserContributionCount Approved { get; set; } = null!;

        [JsonProperty("voted")]
        public UserContributionVoteCount Voted { get; set; } = null!;

        [JsonProperty("commented")]
        public UserContributionVoteCount Commented { get; set; } = null!;

        [JsonProperty("project")]
        public Project Project { get; set; } = null!;
    }
}
