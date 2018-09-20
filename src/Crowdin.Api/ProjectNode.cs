using System;
using Crowdin.Api.Json;
using Newtonsoft.Json;

namespace Crowdin.Api
{
    public abstract class ProjectNode
    {
        [JsonProperty("node_type")]
        public ProjectNodeType NodeType { get; private set; }

        [JsonProperty("id")]
        public Int32 Id { get; private set; }

        [JsonProperty("name")]
        public String Name { get; private set; }
    }

    public sealed class ProjectFileNode : ProjectNode
    {
        [JsonProperty("created")]
        public DateTime Created { get; private set; }

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; private set; }

        [JsonProperty("last_accessed")]
        public DateTime? LastAccessed { get; private set; }

        [JsonProperty("last_revision")]
        public Int32 LastRevision { get; private set; }

        public override String ToString() => $"{Name}";
    }

    public class ProjectFolderNode : ProjectNode
    {
        [JsonProperty("files", ItemConverterType = typeof(ProjectNodeConverter))]
        public ProjectNode[] Files { get; private set; }

        public override String ToString() => $"[{Name}]";
    }

    public sealed class ProjectBranchNode : ProjectFolderNode
    {
        public override String ToString() => $"{{{Name}}}";
    }

    public enum ProjectNodeType
    {
        Branch,
        Directory,
        File
    }
}
