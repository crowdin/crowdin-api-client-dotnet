
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.StringTranslations
{
    [PublicAPI]
    public class TranslationApproval
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
        
        [JsonProperty("translationId")]
        public long TranslationId { get; set; }
        
        [JsonProperty("stringId")]
        public long StringId { get; set; }
        
        [JsonProperty("languageId")]
        public string LanguageId { get; set; }
        
        [JsonProperty("workflowStepId")]
        public long WorkflowStepId { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}