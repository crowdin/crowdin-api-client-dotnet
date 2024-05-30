
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Branches
{
    [PublicAPI]
    public enum BranchMergeStatusId
    {
        [Description("conflict")]
        Conflict,
        
        [Description("failed")]
        Failed,
        
        [Description("inProgress")]
        InProgress,
        
        [Description("merged")]
        Merged
    }
}