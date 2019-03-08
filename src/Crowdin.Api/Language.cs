using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Crowdin.Api
{
    public sealed class Language : IXmlSerializable
    {
        public String Name { get; private set; }

        public String CrowdinCode { get; private set; }

        public override String ToString() => Name;

        XmlSchema IXmlSerializable.GetSchema() => null;

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            Name = reader.ReadRequiredSiblingElementContentAsString("name");
            CrowdinCode = reader.ReadRequiredSiblingElementContentAsString("code");
        }

        void IXmlSerializable.WriteXml(XmlWriter writer) => throw new NotSupportedException();
    }
}
