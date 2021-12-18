
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public enum ProjectVisibility
    {
        [Description("open")]
        Open,
        
        [Description("private")]
        Private
    }
}