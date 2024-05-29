
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public enum AutoApproveOption
    {
        [SerializedValue("all")]
        All,
        
        [SerializedValue("exceptAutoSubstituted")]
        ExceptAutoSubstituted,
        
        [SerializedValue("perfectMatchOnly")]
        PerfectMatchOnly,
        
        [SerializedValue("none")]
        None
    }
}