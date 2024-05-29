
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Distributions
{
    [PublicAPI]
    public enum DistributionReleaseStatus
    {
        [SerializedValue("inProgress")]
        InProgress,
        
        [SerializedValue("success")]
        Success,
        
        [SerializedValue("failed")]
        Failed
    }
}