
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Distributions
{
    [PublicAPI]
    public enum DistributionReleaseStatus
    {
        [Description("inProgress")]
        InProgress,
        
        [Description("success")]
        Success,
        
        [Description("failed")]
        Failed
    }
}