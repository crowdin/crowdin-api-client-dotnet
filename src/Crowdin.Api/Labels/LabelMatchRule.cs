
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Labels
{
    [PublicAPI]
    public enum LabelMatchRule
    {
        [Description("all")]
        All,
        
        [Description("any")]
        Any
    }
}