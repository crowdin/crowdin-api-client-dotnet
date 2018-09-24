using System;
using Crowdin.Api.Protocol;

namespace Crowdin.Api
{
    public sealed class GetLanguageStatusParameters
    {
        [Required]
        public String Language { get; set; }
    }
}