using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Crowdin.Api.Typed
{
    public abstract class ProjectNode : IXmlSerializable
    {
        public Int32 Id { get; private set; }

        public String Name { get; private set; }

        XmlSchema IXmlSerializable.GetSchema() => null;

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            ReadXml(reader);
        }

        void IXmlSerializable.WriteXml(XmlWriter writer) => throw new NotSupportedException();

        internal static ProjectNode LoadFromXml(XmlReader reader)
        {
            reader.ReadStartElement();
            ProjectNodeType projectNodeType = reader.ReadRequiredSiblingElementContentAsEnum<ProjectNodeType>("node_type");
            ProjectNode projectNode;
            switch (projectNodeType)
            {
                case ProjectNodeType.File:
                    projectNode = new ProjectFile();
                    break;
                case ProjectNodeType.Directory:
                    projectNode = new ProjectFolder();
                    break;
                case ProjectNodeType.Branch:
                    projectNode = new ProjectBranch();
                    break;
                default:
                    throw new XmlException();
            }
            ((IXmlSerializable)projectNode).ReadXml(reader);
            return projectNode;
        }

        protected virtual void ReadXml(XmlReader reader)
        {
            Id = reader.ReadRequiredSiblingElementContentAsInt("id");
            Name = reader.ReadRequiredSiblingElementContentAsString("name");
        }
    }

    public sealed class ProjectFile : ProjectNode
    {
        public DateTime Created { get; private set; }

        public DateTime LastUpdated { get; private set; }

        public DateTime? LastAccessed { get; private set; }

        public Int32 LastRevision { get; private set; }

        public override String ToString() => $"{Name}";

        protected override void ReadXml(XmlReader reader)
        {
            base.ReadXml(reader);
            Created = reader.ReadRequiredSiblingElementContentAsIsoDateTime("created");
            LastUpdated = reader.ReadRequiredSiblingElementContentAsIsoDateTime("last_updated");
            LastAccessed = reader.ReadOptionalSiblingElementContentAsIsoDateTime("last_accessed");
            LastRevision = reader.ReadRequiredSiblingElementContentAsInt("last_revision");
        }
    }

    public class ProjectFolder : ProjectNode
    {
        public ReadOnlyCollection<ProjectNode> Files { get; private set; }

        public override String ToString() => $"[{Name}]";

        protected override void ReadXml(XmlReader reader)
        {
            base.ReadXml(reader);
            Files = reader.ReadRequiredSiblingElementSubtreeAsCollection("files", "item", ProjectNode.LoadFromXml)
                .ToList()
                .AsReadOnly();
        }
    }

    public sealed class ProjectBranch : ProjectFolder
    {
        public override String ToString() => $"{{{Name}}}";
    }

    internal enum ProjectNodeType
    {
        Branch,
        Directory,
        File
    }
}
