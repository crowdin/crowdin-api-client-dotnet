
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class ReplaceProjectMemberPermissionsRequest
    {
        [JsonProperty("accessToAllWorkflowSteps")]
        public bool? AccessToAllWorkflowSteps { get; set; }
        
        [JsonProperty("managerAccess")]
        public bool? ManagerAccess { get; set; }
        
        [JsonProperty("permissions")]
        public IDictionary<string, LanguagePermission>? Permissions { get; set; }
    }
}