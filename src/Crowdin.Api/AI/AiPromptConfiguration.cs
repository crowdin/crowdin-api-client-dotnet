
using JetBrains.Annotations;
using Newtonsoft.Json;

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
        public string CompanyDescription { get; set; }
        
        [JsonProperty("projectDescription")]
        public string ProjectDescription { get; set; }
        
        [JsonProperty("audienceDescription")]
        public string AudienceDescription { get; set; }
        
        [JsonProperty("otherLanguageTranslations")]
        public OtherLanguageTranslationsConfig OtherLanguageTranslations { get; set; }
        
        [JsonProperty("glossaryTerms")]
        public bool GlossaryTerms { get; set; }
        
        [JsonProperty("tmSuggestions")]
        public bool TmSuggestions { get; set; }
        
        [JsonProperty("fileContent")]
        public bool FileContent { get; set; }
        
        [JsonProperty("fileContext")]
        public bool FileContext { get; set; }
        
        [JsonProperty("publicProjectDescription")]
        public bool PublicProjectDescription { get; set; }
        
        [PublicAPI]
        public class OtherLanguageTranslationsConfig // TODO: to outer?
        {
            [JsonProperty("isEnabled")]
            public bool IsEnabled { get; set; }
            
            [JsonProperty("languageIds")]
            public string[] LanguageIds { get; set; }
        }
    }
    
    [PublicAPI]
    public class AdvancedModeAiPromptConfiguration : AiPromptConfiguration
    {
        [JsonProperty("mode")]
        public override AiPromptMode Mode => AiPromptMode.Advanced;
        
        [JsonProperty("prompt")]
        public string Prompt { get; set; }
    }
}