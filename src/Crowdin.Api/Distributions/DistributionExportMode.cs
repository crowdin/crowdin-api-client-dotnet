
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Distributions
{
    [PublicAPI]
    public enum DistributionExportMode
    {
        [SerializedValue("default")]
        Default,
        
        [SerializedValue("bundle")]
        Bundle
    }
}