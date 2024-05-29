
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Branches
{
    [PublicAPI]
    public enum BranchesSortingRule
    {
        [SerializedValue("id")]
        Id,
        
        [SerializedValue("name")]
        Name,
        
        [SerializedValue("title")]
        Title,
        
        [SerializedValue("createdAt")]
        CreatedAt,
        
        [SerializedValue("updatedAt")]
        UpdatedAt,
        
        [SerializedValue("exportPattern")]
        ExportPattern,
        
        [SerializedValue("priority")]
        Priority
    }
}