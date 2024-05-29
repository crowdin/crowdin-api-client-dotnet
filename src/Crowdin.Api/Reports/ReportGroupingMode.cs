
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public enum ReportGroupingMode
    {
        [SerializedValue("user")]
        User,
            
        [SerializedValue("language")]
        Language
    }
}