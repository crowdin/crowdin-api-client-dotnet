
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public enum LanguageAccessPolicy
    {
        [Description("open")]
        Open,
        
        [Description("moderate")]
        Moderate
    }
}