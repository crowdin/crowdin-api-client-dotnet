#nullable enable

using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public class OrganizationConcordanceSearchRequest
    {
        [JsonProperty("sourceLanguageId")]
        public string SourceLanguageId { get; set; } = null!;

        [JsonProperty("targetLanguageId")]
        public string TargetLanguageId { get; set; } = null!;

        [JsonProperty("expressions")]
        public IEnumerable<string> Expressions { get; set; } = null!;

        [JsonProperty("userId")]
        public long? UserId { get; set; }
    }
}
