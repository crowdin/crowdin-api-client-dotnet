using Newtonsoft.Json;

namespace Crowdin.Api.Translations
{
    public class ImportFileStatistics
    {
        [JsonProperty("phrases")]
        public int Phrases { get; set; }

        [JsonProperty("words")]
        public int Words { get; set; }
    }
}