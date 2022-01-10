
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class ProjectMember
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("username")]
#pragma warning disable CS8618
        public string Username { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }
        
        [JsonProperty("lastName")]
        public string? LastName { get; set; }
        
        [JsonProperty("isManager")]
        public bool IsManager { get; set; }
        
        [JsonProperty("managerOfGroup")]
        public ProjectGroup? ManagerOfGroup { get; set; }
        
        [JsonProperty("accessToAllWorkflowSteps")]
        public bool AccessToAllWorkflowSteps { get; set; }
        
        [JsonProperty("permissions")]
#pragma warning disable CS8618
        public IDictionary<string, LanguagePermission> Permissions { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("givenAccessAt")]
        public DateTimeOffset? GivenAccessAt { get; set; }
    }
}