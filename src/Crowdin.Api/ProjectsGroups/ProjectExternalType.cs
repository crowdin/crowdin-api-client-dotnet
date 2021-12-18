
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public enum ProjectExternalType
    {
        [Description("translate")]
        Translate,
        
        [Description("proofread")]
        Proofread
    }
}