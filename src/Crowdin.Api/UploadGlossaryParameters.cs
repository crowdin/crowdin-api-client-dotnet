using System;
using System.IO;

namespace Crowdin.Api
{
    public sealed class UploadGlossaryParameters
    {
        [Required]
        public FileInfo File { get; set; }

        [Property("first_line_contains_header")]
        public Boolean? FirstLineContainsHeader { get; set; }

        public String Scheme { get; set; }
    }
}