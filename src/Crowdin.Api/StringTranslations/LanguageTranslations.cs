
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.StringTranslations
{
    [PublicAPI]
    public abstract class LanguageTranslations
    {
        
    }

    [PublicAPI]
    public class PlainLanguageTranslations : LanguageTranslations
    {
        [JsonProperty("stringId")]
        public long StringId { get; set; }
        
        [JsonProperty("contentType")]
        public string ContentType { get; set; }
        
        [JsonProperty("translationId")]
        public long TranslationId { get; set; }
        
        [JsonProperty("text")]
        public string Text { get; set; }
        
        [JsonProperty("user")]
        public User User { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
    }

    [PublicAPI]
    public class PluralLanguageTranslations : LanguageTranslations
    {
        [JsonProperty("stringId")]
        public long StringId { get; set; }
        
        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        [JsonProperty("plurals")]
        public PluralsEntry[] Plurals { get; set; }
        
        public class PluralsEntry
        {
            [JsonProperty("translationId")]
            public long TranslationId { get; set; }
            
            [JsonProperty("text")]
            public string Text { get; set; }
            
            [JsonProperty("pluralForm")]
            public string PluralForm { get; set; }
            
            [JsonProperty("user")]
            public User User { get; set; }
            
            [JsonProperty("createdAt")]
            public DateTimeOffset CreatedAt { get; set; }
        }
    }

    [PublicAPI]
    public class IcuLanguageTranslations : LanguageTranslations
    {
        [JsonProperty("stringId")]
        public long StringId { get; set; }
        
        [JsonProperty("contentType")]
        public string ContentType { get; set; }
        
        [JsonProperty("translationId")]
        public long TranslationId { get; set; }
            
        [JsonProperty("text")]
        public string Text { get; set; }
        
        [JsonProperty("user")]
        public User User { get; set; }
            
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}