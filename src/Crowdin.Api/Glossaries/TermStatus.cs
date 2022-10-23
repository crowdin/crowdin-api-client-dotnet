
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public enum TermStatus
    {
        [Description("preferred")]
        Preferred,
        
        [Description("admitted")]
        Admitted,
        
        [Description("not recommended")]
        NotRecommended,
        
        [Description("obsolete")]
        Obsolete
    }
}