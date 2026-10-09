using System;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;

namespace Crowdin.Api.Applications
{
    [PublicAPI]
    public class ApplicationPermissions
    {
        [JsonProperty("user")]
        [Obsolete(MessageTexts.UseModulePermissionsInstead, false)]
        public ApplicationUser User { get; set; }

        [JsonProperty("project")]
        public ApplicationProject Project { get; set; }

    }
}
