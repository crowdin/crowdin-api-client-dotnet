
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    public class RevisionResource
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("projectId")]
        public int ProjectId { get; set; }
        
        [JsonProperty("fileId")]
        public int FileId { get; set; }
        
        [JsonProperty("restoreToRevision")]
        public int? RestoreToRevision { get; set; }
        
        [JsonProperty("info")]
        public InfoContainer Info { get; set; }
        
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }
        
        [PublicAPI]
        public class InfoContainer
        {
            [JsonProperty("added")]
            public RevisionInfo Added { get; set; }
        
            [JsonProperty("deleted")]
            public RevisionInfo Deleted { get; set; }
        
            [JsonProperty("updated")]
            public RevisionInfo Updated { get; set; }
        }
    }

    [PublicAPI]
    public class RevisionInfo
    {
        [JsonProperty("strings")]
        public int Strings { get; set; }
        
        [JsonProperty("words")]
        public int Words { get; set; }
    }
}