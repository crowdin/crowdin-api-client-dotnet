
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    public enum FileStatus
    {
        [Description("active")]
        Active,
        
        [Description("not_imported")]
        NotImported,
        
        [Description("not_configured")]
        NotConfigured
    }
}