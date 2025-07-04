
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Labels
{
    [PublicAPI]
    public class AssignLabelToScreenshotsRequest
    {
        [JsonProperty("screenshotIds")]
        public ICollection<long> ScreenshotIds { get; set; }
    }
}