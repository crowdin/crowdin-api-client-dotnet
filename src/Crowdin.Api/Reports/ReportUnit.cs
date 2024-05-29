
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public enum ReportUnit
    {
        [SerializedValue("strings")]
        Strings,
        
        [SerializedValue("words")]
        Words,
        
        [SerializedValue("chars")]
        Chars,
        
        [SerializedValue("chars_with_spaces")]
        CharsWithSpaces
    }
}