
using System;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    [Obsolete(MessageTexts.UseBranchesNamespace)]
    public class AddBranchRequest
    {
        [JsonProperty("name")]
#pragma warning disable CS8618
        public string Name { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("title")]
        public string? Title { get; set; }
        
        [JsonProperty("exportPattern")]
        public string? ExportPattern { get; set; }

        [JsonProperty("priority")]
        public Priority? Priority { get; set; }
    }
}