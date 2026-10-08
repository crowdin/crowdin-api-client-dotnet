#nullable enable

using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public enum AiSnippetPatchPath
    {
        [System.ComponentModel.Description("/description")]
        Description,

        [System.ComponentModel.Description("/placeholder")]
        Placeholder,

        [System.ComponentModel.Description("/value")]
        Value
    }
}
