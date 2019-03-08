using System;
using Crowdin.Api.Protocol;

namespace Crowdin.Api.Typed
{
    public sealed class GetLanguageStatusParameters
    {
        [Required]
        public String Language { get; set; }
    }
}