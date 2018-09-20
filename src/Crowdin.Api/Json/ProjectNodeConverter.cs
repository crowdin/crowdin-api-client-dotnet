using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Json
{
    internal sealed class ProjectNodeConverter : JsonConverter<ProjectNode>
    {
        public override Boolean CanWrite => false;

        public override void WriteJson(JsonWriter writer, ProjectNode value, JsonSerializer serializer) => throw new InvalidOperationException();

        public override ProjectNode ReadJson(JsonReader reader, Type objectType, ProjectNode existingValue, Boolean hasExistingValue, JsonSerializer serializer)
        {
            JObject node = JObject.Load(reader);
            ProjectNode projectNode = default;
            switch (node["node_type"].ToObject<ProjectNodeType>())
            {
                case ProjectNodeType.Branch:
                    projectNode = new ProjectBranchNode();
                    break;
                case ProjectNodeType.Directory:
                    projectNode = new ProjectFolderNode();
                    break;
                case ProjectNodeType.File:
                    projectNode = new ProjectFileNode();
                    break;
            }

            serializer.Populate(node.CreateReader(), projectNode);
            return projectNode;
        }
    }
}
