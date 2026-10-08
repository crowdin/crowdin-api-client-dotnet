#nullable enable

using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Placeholders
{
    [PublicAPI]
    public enum CustomPlaceholderPatchPath
    {
        [Description("/description")]
        Description,

        [Description("/definition")]
        Definition,

        [Description("/argumentDelimiter")]
        ArgumentDelimiter
    }
}
