
using System;
using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class ReplaceProjectMemberPermissionsRequest
    {
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