
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.TranslationMemory
{
    [PublicAPI]
    public class CreateTmSegmentRecordsRequest
    {
        [JsonProperty("records")]
        public ICollection<TmSegmentRecordForm> Records { get; set; }
    }
}