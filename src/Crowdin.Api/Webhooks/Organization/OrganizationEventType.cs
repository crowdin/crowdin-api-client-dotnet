
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Webhooks.Organization
{
    [PublicAPI]
    public enum OrganizationEventType
    {
        [SerializedValue("project.created")]
        ProjectCreated,
        
        [SerializedValue("project.deleted")]
        ProjectDeleted
    }
}