
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class Project : ProjectBase
    {
        [JsonProperty("languageAccessPolicy")]
        public LanguageAccessPolicy LanguageAccessPolicy { get; set; }

        [JsonProperty("cname")]
        public string Cname { get; set; }

        [JsonProperty("visibility")]
        public ProjectVisibility Visibility { get; set; }
    }
}