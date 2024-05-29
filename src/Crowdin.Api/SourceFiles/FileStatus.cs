
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    public enum FileStatus
    {
        [SerializedValue("active")]
        Active,
        
        [SerializedValue("not_imported")]
        NotImported,
        
        [SerializedValue("not_configured")]
        NotConfigured
    }
}