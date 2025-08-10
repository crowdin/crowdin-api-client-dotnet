using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.StringCorrections
{
    [PublicAPI]
    public class AddCorrectionRequest
    {
        [JsonProperty("stringId")]
        public string StringId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("pluralCategoryName")]
        public string PluralCategoryName { get; set; }
    }
}