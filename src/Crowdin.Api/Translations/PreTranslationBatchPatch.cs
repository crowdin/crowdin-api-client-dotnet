
using System.ComponentModel;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;
using Crowdin.Api.Core.Converters;

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public class PreTranslationBatchOpPatch : PatchEntry
    {
        [JsonProperty("path")]
        public PreTranslationBatchOpPatchPath Path { get; set; }
    }

    [PublicAPI]
    [CallToStringForSerialization]
    public class PreTranslationBatchOpPatchPath
    {
        public string PreTranslationId { get; set; }

        public PropertyEntry Property { get; set; }

        public override string ToString()
        {
            return $"/{PreTranslationId}{Property.ToDescriptionString()}";
        }

        [PublicAPI]
        public enum PropertyEntry
        {
            [Description("/status")]
            Status,

            [Description("/priority")]
            Priority
        }
    }
}
