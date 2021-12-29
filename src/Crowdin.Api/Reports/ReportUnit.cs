
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public enum ReportUnit
    {
        [Description("strings")]
        Strings,
        
        [Description("words")]
        Words,
        
        [Description("chars")]
        Chars,
        
        [Description("chars_with_spaces")]
        CharsWithSpaces
    }
}