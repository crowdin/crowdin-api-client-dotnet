using System.ComponentModel;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;
using Crowdin.Api.Core.Converters;

namespace Crowdin.Api.TranslationMemory
{
    [PublicAPI]
    public class TmSegmentBatchOpPatch : PatchEntry
    {
        [JsonProperty("path")]
        public TmSegmentBatchOpPatchPath Path { get; set; } = new TmSegmentBatchOpPatchPath();
    }

    [PublicAPI]
    [CallToStringForSerialization]
    public class TmSegmentBatchOpPatchPath
    {
        public long? SegmentId { get; set; }

        public long? RecordId { get; set; }

        public TmSegmentBatchOpPatchPathEntry? Property { get; set; }

        public TmSegmentBatchOpPatchPath()
        {
        }

        public TmSegmentBatchOpPatchPath(
            long? segmentId = null,
            long? recordId = null,
            TmSegmentBatchOpPatchPathEntry? property = null)
        {
            SegmentId = segmentId;
            RecordId = recordId;
            Property = property;
        }

        public override string ToString()
        {
            if (!SegmentId.HasValue && !RecordId.HasValue && !Property.HasValue)
            {
                return "/-";
            }

            if (SegmentId.HasValue && !RecordId.HasValue && !Property.HasValue)
            {
                return $"/{SegmentId}";
            }

            if (SegmentId.HasValue && !RecordId.HasValue && Property == TmSegmentBatchOpPatchPathEntry.Records)
            {
                return $"/{SegmentId}/records/-";
            }

            if (SegmentId.HasValue && RecordId.HasValue && !Property.HasValue)
            {
                return $"/{SegmentId}/records/{RecordId}";
            }

            if (SegmentId.HasValue && RecordId.HasValue && Property == TmSegmentBatchOpPatchPathEntry.Text)
            {
                return $"/{SegmentId}/records/{RecordId}{Property.ToDescriptionString()}";
            }

            return string.Empty;
        }

        public static TmSegmentBatchOpPatchPath Empty => new TmSegmentBatchOpPatchPath();
    }

    [PublicAPI]
    public enum TmSegmentBatchOpPatchPathEntry
    {
        [Description("/records")]
        Records,

        [Description("/text")]
        Text
    }
}
