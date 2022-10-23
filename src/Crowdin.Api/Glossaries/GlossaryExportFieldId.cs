
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public enum GlossaryExportFieldId
    {
        [Description("term")]
        Term,
        
        [Description("description")]
        Description,
        
        [Description("partOfSpeech")]
        PartOfSpeech,
        
        [Description("type")]
        Type,
        
        [Description("status")]
        Status,
        
        [Description("gender")]
        Gender,
        
        [Description("note")]
        Note,
        
        [Description("url")]
        Url
    }
}