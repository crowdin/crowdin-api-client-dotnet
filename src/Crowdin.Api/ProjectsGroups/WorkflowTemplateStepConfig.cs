
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public abstract class WorkflowTemplateStepConfig
    {
        [PublicAPI]
        public class TranslateProofread : WorkflowTemplateStepConfig
        {
            [JsonProperty("id")]
            public long? Id { get; set; }
            
            [JsonProperty("languages")]
            public List<string>? Languages { get; set; }
            
            [JsonProperty("assignees")]
            public List<string>? Assignees { get; set; }
        }
        
        [PublicAPI]
        public class ConfigVendor : WorkflowTemplateStepConfig
        {
            [JsonProperty("id")]
            public long? Id { get; set; }
            
            [JsonProperty("languages")]
            public List<string>? Languages { get; set; }
            
            [JsonProperty("vendorId")]
            public long? VendorId { get; set; }
        }
        
        [PublicAPI]
        public class TmPreTranslate : WorkflowTemplateStepConfig
        {
            [JsonProperty("id")]
            public long? Id { get; set; }
            
            [JsonProperty("languages")]
            public List<string>? Languages { get; set; }
            
            [JsonProperty("config")]
            public Config? Config { get; set; }
        }
        
        [PublicAPI]
        public class MtPreTranslate : WorkflowTemplateStepConfig
        {
            [JsonProperty("id")]
            public long? Id { get; set; }
            
            [JsonProperty("languages")]
            public List<string>? Languages { get; set; }
            
            [JsonProperty("mtId")]
            public long? MtId { get; set; }
        }
        
        [PublicAPI]
        public class Config
        {
            [JsonProperty("minRelevant")]
            public int? MinRelevant { get; set; }
            
            [JsonProperty("autoSubstitution")]
            public bool? AutoSubstitution { get; set; }
        }
    }
}