
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api
{
    [PublicAPI]
    public enum TextDirection
    {
        [SerializedValue("ltr")]
        LeftToRight,
        
        [SerializedValue("rtl")]
        RightToLeft
    }
}