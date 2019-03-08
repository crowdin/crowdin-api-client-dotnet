using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Crowdin.Api
{
    [XmlRoot("info")]
    public sealed class ProjectInfo : IXmlSerializable
    {
        public Language SourceLanguage { get; private set; }

        public String Name { get; private set; }

        public String Identifier { get; private set; }

        public DateTime Created { get; private set; }

        public String Description { get; private set; }

        public ProjectJoinPolicy JoinPolicy { get; private set; }

        public DateTime? LastBuild { get; private set; }

        public DateTime LastActivity { get; private set; }

        public Int32 ParticipantsCount { get; private set; }

        public Uri LogoUrl { get; private set; }

        public Int32 TotalStringsCount { get; private set; }

        public Int32 TotalWordsCount { get; private set; }

        public Int32 DuplicateStringsCount { get; private set; }

        public Int32 DuplicateWordsCount { get; private set; }

        public ProjectInviteUrls InviteUrls { get; private set; }

        public ReadOnlyCollection<TargetLanguage> TargetLanguages { get; private set; }

        public ReadOnlyCollection<ProjectNode> Files { get; private set; }

        public override String ToString() => Name;

        XmlSchema IXmlSerializable.GetSchema() => null;

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();

            if (reader.ReadToNextSibling("languages"))
            {
                reader.Read();
                TargetLanguages = reader.ReadSiblingElementsAsCollection<TargetLanguage>("item")
                    .ToList()
                    .AsReadOnly();
            }

            if (reader.ReadToNextSibling("files"))
            {
                reader.Read();
                Files = reader.ReadSiblingElementsAsCollection("item", ProjectNode.LoadFromXml)
                    .ToList()
                    .AsReadOnly();
            }

            if (reader.ReadToNextSibling("details"))
            {
                reader.Read();
                SourceLanguage = reader.ReadRequiredSiblingElementSubtreeAsObject<Language>("source_language");
                Name = reader.ReadRequiredSiblingElementContentAsString("name");
                Identifier = reader.ReadRequiredSiblingElementContentAsString("identifier");
                Created = reader.ReadRequiredSiblingElementContentAsIsoDateTime("created");
                Description = reader.ReadRequiredSiblingElementContentAsString("description");
                JoinPolicy = reader.ReadRequiredSiblingElementContentAsEnum<ProjectJoinPolicy>("join_policy");
                LastBuild = reader.ReadOptionalSiblingElementContentAsIsoDateTime("last_build");
                LastActivity = reader.ReadRequiredSiblingElementContentAsIsoDateTime("last_activity");
                ParticipantsCount = reader.ReadRequiredSiblingElementContentAsInt("participants_count");
                LogoUrl = reader.ReadRequiredSiblingElementContentAsUri("logo_url");
                TotalStringsCount = reader.ReadRequiredSiblingElementContentAsInt("total_strings_count");
                TotalWordsCount = reader.ReadRequiredSiblingElementContentAsInt("total_words_count");
                DuplicateStringsCount = reader.ReadRequiredSiblingElementContentAsInt("duplicate_strings_count");
                DuplicateWordsCount = reader.ReadRequiredSiblingElementContentAsInt("duplicate_words_count");
                InviteUrls = reader.ReadRequiredSiblingElementSubtreeAsObject<ProjectInviteUrls>("invite_url");
            }
        }

        void IXmlSerializable.WriteXml(XmlWriter writer) => throw new NotSupportedException();
    }
}
