
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public enum LanguageAccessPolicy
    {
        [SerializedValue("open")]
        Open,
        
        [SerializedValue("moderate")]
        Moderate
    }
}