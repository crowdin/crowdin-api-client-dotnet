
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Webhooks.Organization
{
    [PublicAPI]
    public enum OrganizationEventType
    {
        [Description("project.created")]
        ProjectCreated,
        
        [Description("project.deleted")]
        ProjectDeleted
    }
}