
using System;
using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class AddProjectMemberRequest
    {
        [JsonProperty("userIds")]
#pragma warning disable CS8618
        public ICollection<int> UserIds { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("accessToAllWorkflowSteps")]
        [Obsolete(MessageTexts.DeprecatedButStillAvailable)]
        public bool? AccessToAllWorkflowSteps { get; set; }
        
        [JsonProperty("managerAccess")]
        public bool? ManagerAccess { get; set; }
        
        [JsonProperty("permissions")]
        [Obsolete(MessageTexts.DeprecatedButStillAvailable)]
        public IDictionary<string, LanguagePermission>? Permissions { get; set; }
        
        [JsonProperty("roles")]
        public ICollection<TranslatorRole>? Roles { get; set; }
    }
}