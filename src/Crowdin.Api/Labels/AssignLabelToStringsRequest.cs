
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Labels
{
    [PublicAPI]
    public class AssignLabelToStringsRequest
    {
        [JsonProperty("stringIds")]
        public ICollection<long> StringIds { get; set; }
    }
}