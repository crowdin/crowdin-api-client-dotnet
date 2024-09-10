
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public abstract class AiPromptConfiguration
    {
        [JsonProperty("mode")]
        public abstract AiPromptMode Mode { get; }
    }
    
    [PublicAPI]
    public class BasicModeAiPromptConfiguration : AiPromptConfiguration
    {
        [JsonProperty("mode")]
        public override AiPromptMode Mode => AiPromptMode.Basic;
        
        [JsonProperty("companyDescription")]
        public string? CompanyDescription { get; set; }
        
        [JsonProperty("projectDescription")]
        public string? ProjectDescription { get; set; }
        
        [JsonProperty("audienceDescription")]
        public string? AudienceDescription { get; set; }
        
        [JsonProperty("otherLanguageTranslations")]
        public OtherLanguageTranslationsConfig? OtherLanguageTranslations { get; set; }
        
        [JsonProperty("glossaryTerms")]
        public bool? GlossaryTerms { get; set; }
        
        [JsonProperty("tmSuggestions")]
        public bool? TmSuggestions { get; set; }
        
        [JsonProperty("fileContent")]
        public bool? FileContent { get; set; }
        
        [JsonProperty("fileContext")]
        public bool? FileContext { get; set; }
        
        [JsonProperty("publicProjectDescription")]
        public bool? PublicProjectDescription { get; set; }
    }

    [PublicAPI]
    public class BasicModeAssistActionAiPromptConfiguration : AiPromptConfiguration
    {
        [JsonProperty("mode")]
        public override AiPromptMode Mode => AiPromptMode.Basic;
        
        [JsonProperty("companyDescription")]
        public string? CompanyDescription { get; set; }
        
        [JsonProperty("projectDescription")]
        public string? ProjectDescription { get; set; }
        
        [JsonProperty("audienceDescription")]
        public string? AudienceDescription { get; set; }
        
        [JsonProperty("otherLanguageTranslations")]
        public OtherLanguageTranslationsConfig? OtherLanguageTranslations { get; set; }
        
        [JsonProperty("glossaryTerms")]
        public bool? GlossaryTerms { get; set; }
        
        [JsonProperty("tmSuggestions")]
        public bool? TmSuggestions { get; set; }
        
        [JsonProperty("fileContext")]
        public bool? FileContext { get; set; }
        
        [JsonProperty("screenshots")]
        public bool? Screenshots { get; set; }
        
        [JsonProperty("publicProjectDescription")]
        public bool? PublicProjectDescription { get; set; }
        
        [JsonProperty("siblingsStrings")]
        public bool? SiblingsStrings { get; set; }
        
        [JsonProperty("filteredStrings")]
        public bool? FilteredStrings { get; set; }
    }
    
    [PublicAPI]
    public class AdvancedModeAiPromptConfiguration : AiPromptConfiguration
    {
        [JsonProperty("mode")]
        public override AiPromptMode Mode => AiPromptMode.Advanced;
        
        [JsonProperty("screenshots")]
        public bool? Screenshots { get; set; }

        [JsonProperty("prompt")]
        public string Prompt { get; set; } = null!;
        
        [JsonProperty("otherLanguageTranslations")]
        public OtherLanguageTranslationsConfig? OtherLanguageTranslations { get; set; }
    }

    [PublicAPI]
    public class ExternalModeAiPromptConfiguration : AiPromptConfiguration
    {
        [JsonProperty("mode")]
        public override AiPromptMode Mode => AiPromptMode.External;

        [JsonProperty("identifier")]
        public string Identifier { get; set; } = null!;

        [JsonProperty("key")]
        public string Key { get; set; } = null!;
        
        [JsonProperty("options")]
        public IDictionary<string, object>? Options { get; set; }
    }
}