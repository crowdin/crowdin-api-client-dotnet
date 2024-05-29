
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public enum ReportLabelIncludeType
    {
        [SerializedValue("strings_with_label")]
        StringsWithLabel,
        
        [SerializedValue("strings_without_label")]
        StringsWithoutLabel
    }
}