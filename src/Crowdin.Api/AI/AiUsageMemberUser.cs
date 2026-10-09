#nullable enable

using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiUsageMemberUser
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; } = null!;

        [JsonProperty("fullName")]
        public string FullName { get; set; } = null!;

        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; } = null!;
    }
}
