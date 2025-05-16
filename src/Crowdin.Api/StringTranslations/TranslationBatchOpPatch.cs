
using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core.Converters;

namespace Crowdin.Api.StringTranslations
{
    [PublicAPI]
    public class TranslationBatchOpPatch : PatchEntry
    {
        [JsonProperty("path")]
        public TranslationBatchOpPatchPath Path { get; set; }
    }

    [PublicAPI]
    [CallToStringForSerialization]
    public class TranslationBatchOpPatchPath
    {
        private readonly string _translationId;

        public TranslationBatchOpPatchPath(int? translationId = null)
        {
            _translationId = translationId?.ToString() ?? "-";
        }

        public override string ToString()
        {
            return $"/{_translationId}";
        }
        
        public static TranslationBatchOpPatchPath Empty => new TranslationBatchOpPatchPath();
    }
}