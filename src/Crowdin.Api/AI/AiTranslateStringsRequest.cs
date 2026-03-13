using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiTranslateStringsRequest
    {
        [JsonProperty("strings")]
        public ICollection<string> Strings { get; set; }

        [JsonProperty("targetLanguageId")]
        public string TargetLanguageId { get; set; }

        [JsonProperty("sourceLanguageId")]
        public string? SourceLanguageId { get; set; }

        [JsonProperty("tmIds")]
        public ICollection<long>? TmIds { get; set; }

        [JsonProperty("glossaryIds")]
        public ICollection<long>? GlossaryIds { get; set; }

        [JsonProperty("aiPromptId")]
        public int? AiPromptId { get; set; }

        [JsonProperty("aiProviderId")]
        public int? AiProviderId { get; set; }

        [JsonProperty("aiModelId")]
        public string? AiModelId { get; set; }

        [JsonProperty("instructions")]
        public ICollection<string>? Instructions { get; set; }

        [JsonProperty("attachmentIds")]
        public ICollection<long>? AttachmentIds { get; set; }
    }
}