#nullable enable

using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public enum GlossaryAccessOption
    {
        [Description("readOnly")]
        ReadOnly,

        [Description("fullAccess")]
        FullAccess,

        [Description("manageDrafts")]
        ManageDrafts
    }
}
