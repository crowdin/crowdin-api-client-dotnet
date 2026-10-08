#nullable enable

using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Crowdin.Api.ProjectsGroups;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class UserProjectLanguageAccess
    {
        [JsonProperty("allContent")]
        public bool AllContent { get; set; }

        [JsonProperty("workflowStepIds")]
        public long[] WorkflowStepIds { get; set; } = null!;
    }
}
