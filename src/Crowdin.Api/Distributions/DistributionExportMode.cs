
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Distributions
{
    [PublicAPI]
    public enum DistributionExportMode
    {
        [Description("default")]
        Default,
        
        [Description("bundle")]
        Bundle
    }
}