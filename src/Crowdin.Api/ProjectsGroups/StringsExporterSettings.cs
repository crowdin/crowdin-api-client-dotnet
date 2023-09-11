using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class StringsExporterSettings
    {
        [JsonProperty("convertPlaceHolders")]
        public bool? ConvertPlaceHolders { get; set; }
    }
    
    [PublicAPI]
    public class AndroidStringsExporterSettings : StringsExporterSettings
    {
        
    }
    
    [PublicAPI]
    public class MacOsxStringsExporterSettings : StringsExporterSettings
    {
        
    }
}