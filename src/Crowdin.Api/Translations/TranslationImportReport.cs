using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crowdin.Api.Translations
{
    public class TranslationImportReport
    {
        [JsonProperty("languages")]
        public IEnumerable<TranslationImportLanguage>? Languages { get; set; }

    }
}