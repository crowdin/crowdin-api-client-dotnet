#nullable enable

using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Applications
{
    [PublicAPI]
    public enum ApplicationKvRecordPatchPath
    {
        [Description("/value")]
        Value,

        [Description("/ttl")]
        Ttl
    }
}
