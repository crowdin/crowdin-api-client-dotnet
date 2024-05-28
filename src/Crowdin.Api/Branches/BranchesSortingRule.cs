
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Branches
{
    [PublicAPI]
    public enum BranchesSortingRule
    {
        [Description("id")]
        Id,
        
        [Description("name")]
        Name,
        
        [Description("title")]
        Title,
        
        [Description("createdAt")]
        CreatedAt,
        
        [Description("updatedAt")]
        UpdatedAt,
        
        [Description("exportPattern")]
        ExportPattern,
        
        [Description("priority")]
        Priority
    }
}