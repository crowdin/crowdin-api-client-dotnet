using Newtonsoft.Json;

namespace Crowdin.Api.Translations
{
    public class ImportSkippedQaCheckCategories
    {
        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("duplicate")]
        public int Duplicate { get; set; }
    }
}