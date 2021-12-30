
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public enum ReportLabelIncludeType
    {
        [Description("strings_with_label")]
        StringsWithLabel,
        
        [Description("strings_without_label")]
        StringsWithoutLabel
    }
}