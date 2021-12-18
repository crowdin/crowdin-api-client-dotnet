
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.TranslationStatus
{
    [PublicAPI]
    public class ProgressResource
    {
        [JsonProperty("words")]
        public ProgressResourceStatus Words { get; set; }
        
        [JsonProperty("phrases")]
        public ProgressResourceStatus Phrases { get; set; }
        
        [JsonProperty("translationProgress")]
        public int TranslationProgress { get; set; }
        
        [JsonProperty("approvalProgress")]
        public int ApprovalProgress { get; set; }
        
        [JsonProperty("languageId")]
        public string LanguageId { get; set; }
    }
}