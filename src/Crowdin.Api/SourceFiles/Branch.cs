
using System;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    [Obsolete(MessageTexts.UseBranchesNamespace)]
    public class Branch
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("projectId")]
        public int ProjectId { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("exportPattern")]
        public string ExportPattern { get; set; }
        
        [JsonProperty("priority")]
        public Priority Priority { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}