
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public enum ProjectExternalType
    {
        [SerializedValue("translate")]
        Translate,
        
        [SerializedValue("proofread")]
        Proofread
    }
}