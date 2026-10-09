using System.ComponentModel;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;
using Crowdin.Api.Core.Converters;

namespace Crowdin.Api.TranslationMemory
{
    [PublicAPI]
    public class TmSegmentPatch : PatchEntry
    {
        [JsonProperty("path")]
        public TmSegmentPatchPath Path { get; set; } = new TmSegmentPatchPath();
    }

    [PublicAPI]
    [CallToStringForSerialization]
    public class TmSegmentPatchPath
    {
        public long? RecordId { get; set; }

        public TmSegmentPatchPathEntry? Property { get; set; }

        public TmSegmentPatchPath()
        {
        }

        public TmSegmentPatchPath(long? recordId = null, TmSegmentPatchPathEntry? property = null)
        {
            RecordId = recordId;
            Property = property;
        }

        public override string ToString()
        {
            if (!RecordId.HasValue && !Property.HasValue)
            {
                return "/records/-";
            }

            if (RecordId.HasValue && !Property.HasValue)
            {
                return $"/records/{RecordId}";
            }

            if (RecordId.HasValue && Property == TmSegmentPatchPathEntry.Text)
            {
                return $"/records/{RecordId}{Property.ToDescriptionString()}";
            }

            return string.Empty;
        }

        public static TmSegmentPatchPath NewRecord => new TmSegmentPatchPath();
    }

    [PublicAPI]
    public enum TmSegmentPatchPathEntry
    {
        [Description("/text")]
        Text
    }
}
