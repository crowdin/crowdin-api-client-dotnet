using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Fields
{
    [PublicAPI]
    public enum FieldType
    {
        [SerializedValue("checkbox")]
        CheckBox,
        
        [SerializedValue("radiobuttons")]
        RadioButtons,
        
        [SerializedValue("date")]
        Date,
        
        [SerializedValue("datetime")]
        DateTime,
        
        [SerializedValue("number")]
        Number,
        
        [SerializedValue("labels")]
        Labels,

        [SerializedValue("select")]
        Select,

        [SerializedValue("multiselect")]
        MultiSelect,

        [SerializedValue("text")]
        Text,

        [SerializedValue("textarea")]
        TextArea,

        [SerializedValue("url")]
        Url
    }
}