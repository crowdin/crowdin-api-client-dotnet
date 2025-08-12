using System;
using System.ComponentModel;
using Crowdin.Api.StringTranslations;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.StringCorrections
{
    [PublicAPI]
    public class Correction
    {
        [JsonProperty("id")]
        public int Id { get; set; }
       
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("pluralCategoryName")]
        public string PluralCategoryName { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}