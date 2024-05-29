
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public enum TermStatus
    {
        [SerializedValue("preferred")]
        Preferred,
        
        [SerializedValue("admitted")]
        Admitted,
        
        [SerializedValue("not recommended")]
        NotRecommended,
        
        [SerializedValue("obsolete")]
        Obsolete
    }
}