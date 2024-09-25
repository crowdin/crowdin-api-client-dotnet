
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public abstract class AiPromptContextResources
    {
        
    }

    [PublicAPI]
    public class PreTranslateActionAiPromptContextResources : AiPromptContextResources
    {
        [JsonProperty("projectId")]
        public int ProjectId { get; set; }

        [JsonProperty("targetLanguageId")]
        public string TargetLanguageId { get; set; } = null!;

        [JsonProperty("stringIds")]
        public ICollection<int> StringIds { get; set; } = null!;
    }

    [PublicAPI]
    public class AssistActionAiPromptContextResources : AiPromptContextResources
    {
        [JsonProperty("projectId")]
        public int ProjectId { get; set; }

        [JsonProperty("targetLanguageId")]
        public string TargetLanguageId { get; set; } = null!;

        [JsonProperty("stringIds")]
        public ICollection<int> StringIds { get; set; } = null!;
        
        [JsonProperty("filteredStringsIds")]
        public ICollection<int>? FilteredStringsIds { get; set; }
    }

    [PublicAPI]
    public class CustomActionAiPromptContextResources : AiPromptContextResources
    {
        [JsonProperty("projectId")]
        public int ProjectId { get; set; }

        [JsonProperty("targetLanguageId")]
        public string TargetLanguageId { get; set; } = null!;

        [JsonProperty("stringIds")]
        public ICollection<int> StringIds { get; set; } = null!;
    }
}