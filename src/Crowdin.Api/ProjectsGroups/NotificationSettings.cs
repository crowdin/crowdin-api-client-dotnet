
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class NotificationSettings
    {
        [JsonProperty("translatorNewStrings")]
        public bool? TranslatorNewStrings { get; set; }

        [JsonProperty("managerNewStrings")]
        public bool? ManagerNewStrings { get; set; }

        [JsonProperty("managerLanguageCompleted")]
        public bool? ManagerLanguageCompleted { get; set; }
    }
}