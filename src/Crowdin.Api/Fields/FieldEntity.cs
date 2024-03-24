using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Fields
{
    [PublicAPI]

    public enum FieldEntity
    {
        [Description("project")]
        Project,
        
        [Description("user")]
        User,
        
        [Description("task")]
        Task,
        
        [Description("file")]
        File,
        
        [Description("translation")]
        Translation,
        
        [Description("string")]
        String,
    }
}