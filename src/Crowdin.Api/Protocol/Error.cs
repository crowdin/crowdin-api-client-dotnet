using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Crowdin.Api.Protocol
{
    [XmlRoot("error")]
    public sealed class Error: IXmlSerializable
    {
        public Int32 Code { get; private set; }

        public String Message { get; private set; }

        XmlSchema IXmlSerializable.GetSchema() => null;

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            reader.Read();
            if (reader.ReadToNextSibling("code"))
            {
                Code = reader.ReadElementContentAsInt();
            }
            if (reader.ReadToNextSibling("message"))
            {
                Message = reader.ReadElementContentAsString();
            }
        }

        void IXmlSerializable.WriteXml(XmlWriter writer) => throw new NotSupportedException();
    }
}
