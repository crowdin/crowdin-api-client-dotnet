using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Crowdin.Api
{
    [XmlRoot("languages")]
    public sealed class SupportedLanguages : IXmlSerializable
    {
        public ReadOnlyCollection<LanguageInfo> Languages { get; private set; }

        XmlSchema IXmlSerializable.GetSchema() => null;

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            Languages = reader.ReadSiblingElementsAsCollection<LanguageInfo>("language")
                .ToList()
                .AsReadOnly();
        }

        void IXmlSerializable.WriteXml(XmlWriter writer) => throw new NotSupportedException();
    }

    public sealed class LanguageInfo : IXmlSerializable
    {
        public String Name { get; private set; }

        public String CrowdinCode { get; private set; }

        public String EditorCode { get; private set; }

        public String Iso6391 { get; private set; }

        public String Iso6393 { get; private set; }

        public String Locale { get; private set; }

        public String AndroidCode { get; private set; }

        public String OsXCode { get; private set; }

        public String OsXLocale { get; private set; }

        public override String ToString() => Name;

        XmlSchema IXmlSerializable.GetSchema() => null;

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            Name = reader.ReadRequiredSiblingElementContentAsString("name");
            CrowdinCode = reader.ReadRequiredSiblingElementContentAsString("crowdin_code");
            EditorCode = reader.ReadRequiredSiblingElementContentAsString("editor_code");
            Iso6391 = reader.ReadRequiredSiblingElementContentAsString("iso_639_1");
            Iso6393 = reader.ReadRequiredSiblingElementContentAsString("iso_639_3");
            Locale = reader.ReadRequiredSiblingElementContentAsString("locale");
            AndroidCode = reader.ReadRequiredSiblingElementContentAsString("android_code");
            OsXCode = reader.ReadRequiredSiblingElementContentAsString("osx_code");
            OsXLocale = reader.ReadRequiredSiblingElementContentAsString("osx_locale");
        }

        void IXmlSerializable.WriteXml(XmlWriter writer) => throw new NotSupportedException();
    }
}
