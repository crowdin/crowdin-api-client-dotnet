
using JetBrains.Annotations;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public enum ProjectType
    {
        FileBased = 0,
        StringBased = 1,
        FileBasedExternal = 2,
        StringBasedExternal = 3
    }
}