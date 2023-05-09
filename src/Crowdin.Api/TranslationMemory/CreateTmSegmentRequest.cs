
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.TranslationMemory
{
    [PublicAPI]
    public class CreateTmSegmentRequest
    {
        [JsonProperty("records")]
        public ICollection<TmSegmentRecordForm> Records { get; set; }
    }
}