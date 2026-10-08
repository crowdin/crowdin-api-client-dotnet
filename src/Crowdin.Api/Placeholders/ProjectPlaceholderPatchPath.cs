#nullable enable

using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Placeholders
{
    [PublicAPI]
    public enum ProjectPlaceholderPatchPath
    {
        [Description("/index")]
        Index,

        [Description("/type")]
        Type,

        [Description("/isBlocking")]
        IsBlocking,

        [Description("/formats")]
        Formats
    }
}
