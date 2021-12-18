
using JetBrains.Annotations;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public enum TagsDetectionAction
    {
        Auto = 0,
        Count = 1,
        Skip = 2
    }
}