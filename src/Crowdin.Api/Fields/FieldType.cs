using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Fields
{
    [PublicAPI]
    public enum FieldType
    {
        [Description("checkbox")]
        CheckBox,
        
        [Description("radiobuttons")]
        RadioButtons,
        
        [Description("date")]
        Date,
        
        [Description("datetime")]
        DateTime,
        
        [Description("number")]
        Number,
        
        [Description("labels")]
        Labels,

        [Description("select")]
        Select,

        [Description("multiselect")]
        MultiSelect,

        [Description("text")]
        Text,

        [Description("textarea")]
        TextArea,

        [Description("url")]
        Url
    }
}