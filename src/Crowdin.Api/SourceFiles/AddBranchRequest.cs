
using System;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    [Obsolete(MessageTexts.UseBranchesNamespace)]
    public class AddBranchRequest : Crowdin.Api.Branches.AddBranchRequest
    {
        [JsonProperty("exportPattern")]
        public string? ExportPattern { get; set; }

        [JsonProperty("priority")]
        public Priority? Priority { get; set; }
    }
}