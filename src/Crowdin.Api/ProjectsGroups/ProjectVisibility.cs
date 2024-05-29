
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public enum ProjectVisibility
    {
        [SerializedValue("open")]
        Open,
        
        [SerializedValue("private")]
        Private
    }
}