
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Branches
{
    [PublicAPI]
    public enum BranchMergeStatusId
    {
        [SerializedValue("conflict")]
        Conflict,
        
        [SerializedValue("failed")]
        Failed,
        
        [SerializedValue("inProgress")]
        InProgress,
        
        [SerializedValue("merged")]
        Merged
    }
}