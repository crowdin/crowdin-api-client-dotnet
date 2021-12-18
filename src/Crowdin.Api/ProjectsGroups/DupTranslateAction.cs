
using JetBrains.Annotations;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public enum DupTranslateAction
    {
        Show = 0,
        Hide = 1,
        ShowAndAutoTranslate = 2,
        ShowWithVersionBranch = 3,
        HideStrict = 4,
        ShowWithVersionBranchStrict = 5
    }
}