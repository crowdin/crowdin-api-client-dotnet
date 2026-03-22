
using System.Collections.Generic;
using Crowdin.Api.SourceFiles;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiFileTranslationsRequest
    {
        [JsonProperty("storageId")]
        public long StorageId { get; set; }
        
        [JsonProperty("sourceLanguageId")]
        public string? SourceLanguageId { get; set; }

        [JsonProperty("targetLanguageId")]
        public string TargetLanguageId { get; set; } = null!;
        
        [JsonProperty("type")]
        public ProjectFileType? Type { get; set; }
        
        [JsonProperty("parserVersion")]
        public int? ParserVersion { get; set; }
        
        [JsonProperty("tmIds")]
        public ICollection<long>? TmIds { get; set; }
        
        [JsonProperty("glossaryIds")]
        public ICollection<long>? GlossaryIds { get; set; }
        
        [JsonProperty("aiPromptId")]
        public long? AiPromptId { get; set; }
        
        [JsonProperty("aiProviderId")]
        public long? AiProviderId { get; set; }
        
        [JsonProperty("aiModelId")]
        public string? AiModelId { get; set; }
        
        [JsonProperty("instructions")]
        public ICollection<string>? Instructions { get; set; }
        
        [JsonProperty("attachmentIds")]
        public ICollection<long>? AttachmentIds { get; set; }
    }
}