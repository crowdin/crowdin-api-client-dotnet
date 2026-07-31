
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class PreTranslateOverridePromptValues
    {
        [JsonProperty("sourceLanguage")]
        public string? SourceLanguage { get; set; }

        [JsonProperty("targetLanguage")]
        public string? TargetLanguage { get; set; }

        [JsonProperty("strings")]
        public string? Strings { get; set; }

        [JsonProperty("tm")]
        public string? Tm { get; set; }

        [JsonProperty("terms")]
        public string? Terms { get; set; }

        [JsonProperty("fileName")]
        public string? FileName { get; set; }

        [JsonProperty("fileContext")]
        public string? FileContext { get; set; }

        [JsonProperty("siblingsStrings")]
        public string? SiblingsStrings { get; set; }

        [JsonProperty("projectName")]
        public string? ProjectName { get; set; }

        [JsonProperty("projectDescription")]
        public string? ProjectDescription { get; set; }

        [JsonProperty("pluralForms")]
        public string? PluralForms { get; set; }

        [JsonProperty("fileContent")]
        public string? FileContent { get; set; }

        [JsonProperty("organizationName")]
        public string? OrganizationName { get; set; }

        [JsonProperty("organizationDescription")]
        public string? OrganizationDescription { get; set; }
    }

    [PublicAPI]
    public class QaCheckOverridePromptValues
    {
        [JsonProperty("sourceLanguage")]
        public string? SourceLanguage { get; set; }

        [JsonProperty("targetLanguage")]
        public string? TargetLanguage { get; set; }

        [JsonProperty("translationUnits")]
        public string? TranslationUnits { get; set; }

        [JsonProperty("tm")]
        public string? Tm { get; set; }

        [JsonProperty("terms")]
        public string? Terms { get; set; }

        [JsonProperty("fileName")]
        public string? FileName { get; set; }

        [JsonProperty("fileContext")]
        public string? FileContext { get; set; }

        [JsonProperty("projectName")]
        public string? ProjectName { get; set; }

        [JsonProperty("projectDescription")]
        public string? ProjectDescription { get; set; }

        [JsonProperty("organizationName")]
        public string? OrganizationName { get; set; }

        [JsonProperty("organizationDescription")]
        public string? OrganizationDescription { get; set; }
    }

    [PublicAPI]
    public class AlignmentOverridePromptValues
    {
        [JsonProperty("sourceLanguage")]
        public string? SourceLanguage { get; set; }

        [JsonProperty("targetLanguage")]
        public string? TargetLanguage { get; set; }

        [JsonProperty("alignmentPairs")]
        public string? AlignmentPairs { get; set; }

        [JsonProperty("projectDescription")]
        public string? ProjectDescription { get; set; }

        [JsonProperty("projectPublicDescription")]
        public string? ProjectPublicDescription { get; set; }

        [JsonProperty("organizationName")]
        public string? OrganizationName { get; set; }

        [JsonProperty("organizationDescription")]
        public string? OrganizationDescription { get; set; }
    }

    [PublicAPI]
    public class CustomOverridePromptValues
    {
        [JsonProperty("sourceLanguage")]
        public string? SourceLanguage { get; set; }

        [JsonProperty("targetLanguage")]
        public string? TargetLanguage { get; set; }

        [JsonProperty("strings")]
        public string? Strings { get; set; }

        [JsonProperty("tm")]
        public string? Tm { get; set; }

        [JsonProperty("terms")]
        public string? Terms { get; set; }

        [JsonProperty("fileName")]
        public string? FileName { get; set; }

        [JsonProperty("fileContext")]
        public string? FileContext { get; set; }

        [JsonProperty("siblingsStrings")]
        public string? SiblingsStrings { get; set; }

        [JsonProperty("projectName")]
        public string? ProjectName { get; set; }

        [JsonProperty("projectDescription")]
        public string? ProjectDescription { get; set; }

        [JsonProperty("pluralForms")]
        public string? PluralForms { get; set; }

        [JsonProperty("fileContent")]
        public string? FileContent { get; set; }

        [JsonProperty("filteredStrings")]
        public string? FilteredStrings { get; set; }

        [JsonProperty("organizationName")]
        public string? OrganizationName { get; set; }

        [JsonProperty("organizationDescription")]
        public string? OrganizationDescription { get; set; }
    }
}
