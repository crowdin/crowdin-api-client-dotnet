
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public enum AutoApproveOption
    {
        [Description("all")]
        All,
        
        [Description("exceptAutoSubstituted")]
        ExceptAutoSubstituted,
        
        [Description("perfectMatchOnly")]
        PerfectMatchOnly,
        
        [Description("none")]
        None
    }
}