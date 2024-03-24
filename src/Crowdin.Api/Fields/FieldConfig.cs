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
        [Description("projectCreateModal")]
        ProjectCreateModal,

        [Description("projectHeader")]
        ProjectHeader,
        
        [Description("projectDetails")]
        ProjectDetails,
        
        [Description("projectCrowdsourceDetails")]
        ProjectCrowdSourceDetails,
        
        [Description("projectSettings")]
        ProjectSettings,
        
        [Description("projectTaskEditCreate")]
        ProjectTaskEditCreate,
        
        [Description("projectTaskDetails")]
        ProjectTaskDetails,
        
        [Description("fileDetails")]
        FileDetails,
        
        [Description("fileSettings")]
        FileSettings,
        
        [Description("userEditModal")]
        UserEditModal,
        
        [Description("userDetails")]
        UserDetails,
        
        [Description("userPopover")]
        UserPopOver,
        
        [Description("stringEditModal")]
        StringEditModal,
        
        [Description("stringDetails")]
        StringDetails,
        
        [Description("translationUnderContent")]
        TranslationUnderContent
    }
}