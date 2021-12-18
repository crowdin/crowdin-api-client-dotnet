
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api
{
    [PublicAPI]
    public enum TextDirection
    {
        [Description("ltr")]
        LeftToRight,
        
        [Description("rtl")]
        RightToLeft
    }
}