using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Crowdin.Api.Typed
{
    [XmlRoot("status")]
    public sealed class ProjectTranslationStatus : IXmlSerializable
    {
        public ReadOnlyCollection<TargetLanguageStatus> Languages { get; private set; }

        XmlSchema IXmlSerializable.GetSchema() => null;

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            Languages = reader.ReadSiblingElementsAsCollection<TargetLanguageStatus>("language")
                .ToList()
                .AsReadOnly();
        }

        void IXmlSerializable.WriteXml(XmlWriter writer) => throw new NotSupportedException();
    }

    public sealed class TargetLanguageStatus : IXmlSerializable
    {
        public String Name { get; private set; }

        public String Code { get; private set; }

        public Int32 Phrases { get; private set; }

        public Int32 Translated { get; private set; }

        public Int32 Approved { get; private set; }

        public Int32 Words { get; private set; }

        public Int32 WordsTranslated { get; private set; }

        public Int32 WordsApproved { get; private set; }

        public Int32 TranslateProgress { get; private set; }

        public Int32 ApproveProgress { get; private set; }

        public Int32? QaIssues { get; private set; }

        public override String ToString() => $"{Name}, translated: {TranslateProgress}%, approved: {ApproveProgress}%";

        XmlSchema IXmlSerializable.GetSchema() => null;

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            Name = reader.ReadRequiredSiblingElementContentAsString("name");
            Code = reader.ReadRequiredSiblingElementContentAsString("code");
            Phrases = reader.ReadRequiredSiblingElementContentAsInt("phrases");
            Translated = reader.ReadRequiredSiblingElementContentAsInt("translated");
            Approved = reader.ReadRequiredSiblingElementContentAsInt("approved");
            Words = reader.ReadRequiredSiblingElementContentAsInt("words");
            WordsTranslated = reader.ReadRequiredSiblingElementContentAsInt("words_translated");
            WordsApproved = reader.ReadRequiredSiblingElementContentAsInt("words_approved");
            TranslateProgress = reader.ReadRequiredSiblingElementContentAsInt("translated_progress");
            ApproveProgress = reader.ReadRequiredSiblingElementContentAsInt("approved_progress");
            QaIssues = reader.ReadOptionalSiblingElementContentAsInt("qa_issues");
        }

        void IXmlSerializable.WriteXml(XmlWriter writer) => throw new NotSupportedException();
    }
}
