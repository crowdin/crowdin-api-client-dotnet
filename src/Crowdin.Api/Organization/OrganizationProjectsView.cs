#nullable enable

using System.ComponentModel;

using JetBrains.Annotations;

namespace Crowdin.Api.Organization
{
    [PublicAPI]
    public enum OrganizationProjectsView
    {
        [Description("grid")]
        Grid,

        [Description("list")]
        List
    }
}
