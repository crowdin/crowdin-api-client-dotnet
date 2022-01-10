
using System.Collections.Generic;
using Crowdin.Api.Users;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Teams
{
    [PublicAPI]
    public class AddTeamToProjectRequest
    {
        [JsonProperty("teamId")]
        public int TeamId { get; set; }
        
        [JsonProperty("accessToAllWorkflowSteps")]
        public bool? AccessToAllWorkflowSteps { get; set; }
        
        [JsonProperty("managerAccess")]
        public bool? ManagerAccess { get; set; }
        
        [JsonProperty("permissions")]
        public IDictionary<string, LanguagePermission>? Permissions { get; set; }
    }
}