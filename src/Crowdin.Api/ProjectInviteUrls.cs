using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Crowdin.Api
{
    public sealed class ProjectInviteUrls : IXmlSerializable
    {
        public Uri Translator { get; private set; }

        public Uri Proofreader { get; private set; }

        XmlSchema IXmlSerializable.GetSchema() => null;

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            Translator = reader.ReadRequiredSiblingElementContentAsUri("translator");
            Proofreader = reader.ReadRequiredSiblingElementContentAsUri("proofreader");
        }

        void IXmlSerializable.WriteXml(XmlWriter writer) => throw new NotSupportedException();
    }
}
