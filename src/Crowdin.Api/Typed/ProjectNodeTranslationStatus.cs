using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Crowdin.Api.Typed
{
    public abstract class ProjectNodeTranslationStatus : IXmlSerializable
    {
        public Int32 Id { get; private set; }

        public String Name { get; private set; }

        public Int32 Phrases { get; private set; }

        public Int32 Translated { get; private set; }

        public Int32 Approved { get; private set; }

        public Int32 Words { get; private set; }

        public Int32 WordsTranslated { get; private set; }

        public Int32 WordsApproved { get; private set; }

        XmlSchema IXmlSerializable.GetSchema() => null;

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            ReadXml(reader);
        }

        void IXmlSerializable.WriteXml(XmlWriter writer) => throw new NotSupportedException();

        internal static ProjectNodeTranslationStatus LoadFromXml(XmlReader reader)
        {
            reader.ReadStartElement();
            ProjectNodeType projectNodeType = reader.ReadRequiredSiblingElementContentAsEnum<ProjectNodeType>("node_type");
            ProjectNodeTranslationStatus projectNode;
            switch (projectNodeType)
            {
                case ProjectNodeType.File:
                    projectNode = new ProjectFileTranslationStatus();
                    break;
                case ProjectNodeType.Directory:
                    projectNode = new ProjectFolderTranslationStatus();
                    break;
                case ProjectNodeType.Branch:
                    projectNode = new ProjectBranchTranslationStatus();
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
            Phrases = reader.ReadRequiredSiblingElementContentAsInt("phrases");
            Translated = reader.ReadRequiredSiblingElementContentAsInt("translated");
            Approved = reader.ReadRequiredSiblingElementContentAsInt("approved");
            Words = reader.ReadRequiredSiblingElementContentAsInt("words");
            WordsTranslated = reader.ReadRequiredSiblingElementContentAsInt("words_translated");
            WordsApproved = reader.ReadRequiredSiblingElementContentAsInt("words_approved");
        }
    }

    public sealed class ProjectFileTranslationStatus : ProjectNodeTranslationStatus
    {
        public override String ToString() => $"{Name}";
    }

    public class ProjectFolderTranslationStatus : ProjectNodeTranslationStatus
    {
        public ReadOnlyCollection<ProjectNodeTranslationStatus> Files { get; private set; }

        public override String ToString() => $"[{Name}]";

        protected override void ReadXml(XmlReader reader)
        {
            base.ReadXml(reader);
            Files = reader.ReadRequiredSiblingElementSubtreeAsCollection("files", "item", ProjectNodeTranslationStatus.LoadFromXml)
                .ToList()
                .AsReadOnly();
        }
    }

    public sealed class ProjectBranchTranslationStatus : ProjectFolderTranslationStatus
    {
        public override String ToString() => $"{{{Name}}}";
    }
}
