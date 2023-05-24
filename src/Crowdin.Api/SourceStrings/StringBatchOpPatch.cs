
using System.ComponentModel;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;
using Crowdin.Api.Core.Converters;

namespace Crowdin.Api.SourceStrings
{
    [PublicAPI]
    public class StringBatchOpPatch : PatchEntry
    {
        [JsonProperty("path")]
        public StringBatchOpPatchPath Path { get; set; } = new StringBatchOpPatchPath();
    }

    [PublicAPI]
    [CallToStringForSerialization]
    public class StringBatchOpPatchPath
    {
        public int? StringId { get; set; }
        
        public StringBatchOpPatchPathEntry? Property { get; set; }

        public StringBatchOpPatchPath()
        {
        }

        public StringBatchOpPatchPath(int? stringId = null, StringBatchOpPatchPathEntry? property = null)
        {
            StringId = stringId;
            Property = property;
        }

        public override string ToString()
        {
            if (StringId.HasValue && Property.HasValue)
            {
                return $"/{StringId}{Property.ToDescriptionString()}";
            }

            if (!StringId.HasValue && !Property.HasValue)
            {
                return "/-";
            }

            if (StringId.HasValue && !Property.HasValue)
            {
                return $"/{StringId}";
            }

            return string.Empty;
        }
    }

    [PublicAPI]
    public enum StringBatchOpPatchPathEntry
    {
        [Description("/identifier")]
        Identifier,
        
        [Description("/text")]
        Text,
        
        [Description("/context")]
        Context,
        
        [Description("/isHidden")]
        IsHidden,
        
        [Description("/maxLength")]
        MaxLength,
        
        [Description("/labelIds")]
        LabelIds
    } 
}