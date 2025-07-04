
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class EnterpriseProject : ProjectBase
    {
        [JsonProperty("groupId")]
        public long GroupId { get; set; }
        
        [JsonProperty("background")]
        public string Background { get; set; }
        
        [JsonProperty("isExternal")]
        public bool IsExternal { get; set; }

        [JsonProperty("externalType")]
        public ProjectExternalType? ExternalType { get; set; }
        
        [JsonProperty("workflowId")]
        public long WorkflowId { get; set; }
        
        [JsonProperty("hasCrowdsourcing")]
        public bool HasCrowdSourcing { get; set; }
    }
}