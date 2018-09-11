using System;

namespace Crowdin.Api
{
    public sealed class GetLanguageStatusParameters
    {
        [Required]
        public String Language { get; set; }
    }
}