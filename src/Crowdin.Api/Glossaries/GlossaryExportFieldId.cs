
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public enum GlossaryExportFieldId
    {
        [SerializedValue("term")]
        Term,
        
        [SerializedValue("description")]
        Description,
        
        [SerializedValue("partOfSpeech")]
        PartOfSpeech,
        
        [SerializedValue("type")]
        Type,
        
        [SerializedValue("status")]
        Status,
        
        [SerializedValue("gender")]
        Gender,
        
        [SerializedValue("note")]
        Note,
        
        [SerializedValue("url")]
        Url
    }
}