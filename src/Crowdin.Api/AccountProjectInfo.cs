using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Crowdin.Api
{
    [XmlRoot("success")]
    public sealed class AccountProjects : IXmlSerializable
    {
        public ReadOnlyCollection<AccountProjectInfo> Projects { get; private set; }

        XmlSchema IXmlSerializable.GetSchema() => null;

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            Projects = reader.ReadSiblingElementsAsCollection<AccountProjectInfo>("project")
                .ToList()
                .AsReadOnly();
        }

        void IXmlSerializable.WriteXml(XmlWriter writer) => throw new NotSupportedException();
    }

    public sealed class AccountProjectInfo : IXmlSerializable
    {
        public String Role { get; private set; }

        public String Name { get; private set; }

        public String Identifier { get; private set; }

        public Boolean Downloadable { get; private set; }

        public String Key { get; private set; }

        public override String ToString() => Name;

        XmlSchema IXmlSerializable.GetSchema() => null;

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            Role = reader.ReadRequiredSiblingElementContentAsString("role");
            Name = reader.ReadRequiredSiblingElementContentAsString("name");
            Identifier = reader.ReadRequiredSiblingElementContentAsString("identifier");
            Downloadable = reader.ReadRequiredSiblingElementContentAsBoolean("downloadable");
            Key = reader.ReadRequiredSiblingElementContentAsString("key");
        }

        void IXmlSerializable.WriteXml(XmlWriter writer) => throw new NotSupportedException();
    }
}
