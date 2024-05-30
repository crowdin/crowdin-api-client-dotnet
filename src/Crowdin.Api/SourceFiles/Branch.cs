
using System;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    [Obsolete(MessageTexts.UseBranchesNamespace)]
    public class Branch : Crowdin.Api.Branches.Branch
    {
        [JsonProperty("exportPattern")]
        public string ExportPattern { get; set; }
        
        [JsonProperty("priority")]
        public Priority Priority { get; set; }
    }
}