using System;
using Crowdin.Api.Json;
using Newtonsoft.Json;

namespace Crowdin.Api
{
    public sealed class ProjectInfo
    {
        [JsonProperty("languages")]
        public TargetLanguage[] TargetLanguages { get; private set; }

        [JsonProperty("files", ItemConverterType = typeof(ProjectNodeConverter))]
        public ProjectNode[] Files { get; private set; }

        [JsonProperty("details")]
        public ProjectDetails Details { get; private set; }

        public override String ToString() => Details?.Name ?? base.ToString();
    }

    public sealed class ProjectDetails
    {
        [JsonProperty("source_language")]
        public Language SourceLanguage { get; private set; }

        [JsonProperty("name")]
        public String Name { get; private set; }

        [JsonProperty("identifier")]
        public String Identifier { get; private set; }

        [JsonProperty("created")]
        public DateTime Created { get; private set; }

        [JsonProperty("description")]
        public String Description { get; private set; }

        [JsonProperty("join_policy")]
        public ProjectJoinPolicy JoinPolicy { get; private set; }

        [JsonProperty("last_build")]
        public DateTime? LastBuild { get; private set; }

        [JsonProperty("last_activity")]
        public DateTime LastActivity { get; private set; }

        [JsonProperty("participants_count")]
        public Int32 ParticipantsCount { get; private set; }

        [JsonProperty("logo_url")]
        public Uri LogoUrl { get; private set; }

        [JsonProperty("total_strings_count")]
        public Int32 TotalStringsCount { get; private set; }

        [JsonProperty("total_words_count")]
        public Int32 TotalWordsCount { get; private set; }

        [JsonProperty("duplicate_strings_count")]
        public Int32 DuplicateStringsCount { get; private set; }

        [JsonProperty("duplicate_words_count")]
        public Int32 DuplicateWordsCount { get; private set; }

        [JsonProperty("invite_url")]
        public ProjectInviteUrls InviteUrls { get; private set; }
    }
}
