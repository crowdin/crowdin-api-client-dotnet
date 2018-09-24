using System;
using Crowdin.Api.Protocol;

namespace Crowdin.Api
{
    public sealed class DeleteFileParameters
    {
        [Required]
        public String File { get; set; }

        public String Branch { get; set; }
    }
}