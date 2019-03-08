using System;
using System.Collections.Generic;
using System.IO;
using Crowdin.Api.Protocol;

namespace Crowdin.Api.Typed
{
    public sealed class UpdateFileParameters
    {
        [Required]
        public IDictionary<String, FileInfo> Files { get; set; }

        public IDictionary<String, String> Titles { get; set; }

        [Property("export_patterns")]
        public IDictionary<String, String> ExportPatterns { get; set; }

        [Property("new_names")]
        public IDictionary<String, String> NewNames { get; set; }

        public String Type { get; set; }

        [Property("first_line_contains_header")]
        public Boolean? FirstLineContainsHeader { get; set; }

        public String Scheme { get; set; }

        [Property("update_option")]
        public UpdateFileOption? UpdateOption { get; set; }

        public String Branch { get; set; }
    }
}