
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api
{
    [PublicAPI]
    public enum Priority
    {
        [Description("low")]
        Low,
        
        [Description("normal")]
        Normal,
        
        [Description("high")]
        High
    }
}