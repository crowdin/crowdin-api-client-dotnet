
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Labels
{
    [PublicAPI]
    public class AssignLabelToScreenshotsRequest
    {
        [JsonProperty("screenshotIds")]
        public ICollection<int> ScreenshotIds { get; set; }
    }
}