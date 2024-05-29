using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Fields
{
    [PublicAPI]

    public enum FieldEntity
    {
        [SerializedValue("project")]
        Project,
        
        [SerializedValue("user")]
        User,
        
        [SerializedValue("task")]
        Task,
        
        [SerializedValue("file")]
        File,
        
        [SerializedValue("translation")]
        Translation,
        
        [SerializedValue("string")]
        String,
    }
}