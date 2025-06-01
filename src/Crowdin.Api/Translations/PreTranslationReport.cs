
using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.TranslationStatus;

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public class PreTranslationReport
    {
        [JsonProperty("languages")]
        public TargetLanguage[] Languages { get; set; }
        
        [JsonProperty("preTranslateType")]
        public PreTranslationMethod PreTranslateType { get; set; }
    }

    [PublicAPI]
    public class TargetLanguage
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("files")]
        public File[] Files { get; set; }
        
        [JsonProperty("skipped")]
        public SkippedObject Skipped { get; set; }
        
        [JsonProperty("skippedQaCheckCategories")]
        public QaCheckIssueCategory[] SkippedQaCheckCategories { get; set; }
        
        [PublicAPI]
        public class File
        {
            [JsonProperty("id")]
            public string Id { get; set; }
            
            [JsonProperty("statistics")]
            public FileStatistics Statistics { get; set; }

            [PublicAPI]
            public class FileStatistics
            {
                [JsonProperty("phrases")]
                public int Phrases { get; set; }
                
                [JsonProperty("words")]
                public int Words { get; set; }
            }
        }

        [PublicAPI]
        public class SkippedObject
        {
            [JsonProperty("ai_error")]
            public int AiError { get; set; }
        }
    }
}