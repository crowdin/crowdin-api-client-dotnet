using System;
using Crowdin.Api.Protocol;

namespace Crowdin.Api
{
    public sealed class CreateFolderParameters
    {
        [Required]
        public String Name { get; set; }

        public String Title { get; set; }

        [Property("export_pattern")]
        public String ExportPattern { get; set; }

        public Boolean? Recursive { get; set; }

        [Property("is_branch")]
        public Boolean? IsBranch { get; set; }

        public String Branch { get; set; }
    }
}