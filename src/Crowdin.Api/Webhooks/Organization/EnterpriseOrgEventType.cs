
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Webhooks.Organization
{
    [PublicAPI]
    public enum EnterpriseOrgEventType
    {
        [Description("group.created")]
        GroupCreated,
        
        [Description("group.deleted")]
        GroupDeleted,
        
        [Description("project.created")]
        ProjectCreated,
        
        [Description("project.deleted")]
        ProjectDeleted
    }
}