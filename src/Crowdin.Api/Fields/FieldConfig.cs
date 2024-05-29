using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Fields
{
    [PublicAPI]
    public class FieldConfig
    {
        [JsonProperty("locations")]
        public Location[] Locations { get; set; }
    }

    [PublicAPI]
    public class ListFieldConfig : FieldConfig
    {
        [JsonProperty("options")]
        public Option[] Options { get; set; }
    }

    [PublicAPI]
    public class NumberFieldConfig : FieldConfig
    {
        [JsonProperty("min")]
        public int Min { get; set; }
        
        [JsonProperty("max")]
        public int Max { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }
    }
    
    [PublicAPI]
    public class Option
    {
        [JsonProperty("label")]
        public string Label { get; set; }        

        [JsonProperty("value")]
        public string Value { get; set; }        
    }

    [PublicAPI]
    public class Location
    {
        [JsonProperty("place")]
        public Place Place { get; set; }
    }

    [PublicAPI]
    public enum Place
    {
        [SerializedValue("projectCreateModal")]
        ProjectCreateModal,

        [SerializedValue("projectHeader")]
        ProjectHeader,
        
        [SerializedValue("projectDetails")]
        ProjectDetails,
        
        [SerializedValue("projectCrowdsourceDetails")]
        ProjectCrowdSourceDetails,
        
        [SerializedValue("projectSettings")]
        ProjectSettings,
        
        [SerializedValue("projectTaskEditCreate")]
        ProjectTaskEditCreate,
        
        [SerializedValue("projectTaskDetails")]
        ProjectTaskDetails,
        
        [SerializedValue("fileDetails")]
        FileDetails,
        
        [SerializedValue("fileSettings")]
        FileSettings,
        
        [SerializedValue("userEditModal")]
        UserEditModal,
        
        [SerializedValue("userDetails")]
        UserDetails,
        
        [SerializedValue("userPopover")]
        UserPopOver,
        
        [SerializedValue("stringEditModal")]
        StringEditModal,
        
        [SerializedValue("stringDetails")]
        StringDetails,
        
        [SerializedValue("translationUnderContent")]
        TranslationUnderContent
    }
}