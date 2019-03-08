using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Crowdin.Api.Typed
{
    [XmlRoot("status")]
    public sealed class LanguageTranslationStatus : IXmlSerializable
    {
        public ReadOnlyCollection<ProjectNodeTranslationStatus> Files { get; private set; }

        XmlSchema IXmlSerializable.GetSchema() => null;

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            Files = reader.ReadRequiredSiblingElementSubtreeAsCollection("files", "item", ProjectNodeTranslationStatus.LoadFromXml)
                .ToList()
                .AsReadOnly();
        }

        void IXmlSerializable.WriteXml(XmlWriter writer) => throw new NotSupportedException();
    }
}
