using Newtonsoft.Json;

namespace Crowdin.Api.Translations
{
    public class TranslationImportFile
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("statistics")]
        public ImportFileStatistics Statistics { get; set; }
    }
}