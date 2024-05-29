
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Webhooks.Organization
{
    [PublicAPI]
    public enum EnterpriseOrgEventType
    {
        [SerializedValue("group.created")]
        GroupCreated,
        
        [SerializedValue("group.deleted")]
        GroupDeleted,
        
        [SerializedValue("project.created")]
        ProjectCreated,
        
        [SerializedValue("project.deleted")]
        ProjectDeleted
    }
}