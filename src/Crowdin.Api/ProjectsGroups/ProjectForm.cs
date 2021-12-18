
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public abstract class ProjectForm : AddProjectRequest
    {
        [JsonProperty("type")]
        public ProjectType? Type { get; set; }
    }
}