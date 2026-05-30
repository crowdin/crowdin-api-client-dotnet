
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.TranslationStatus
{
    [PublicAPI]
    public class RevalidateQaChecksRequest
    {
        [JsonProperty("qaCheckCategories")]
        public ICollection<QaCheckRevalidationCategory>? QaCheckCategories { get; set; }

        [JsonProperty("languageIds")]
        public ICollection<string>? LanguageIds { get; set; }

        [JsonProperty("failedOnly")]
        public bool? FailedOnly { get; set; }
    }
}
