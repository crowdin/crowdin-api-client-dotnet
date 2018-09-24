using System;
using Crowdin.Api.Protocol;

namespace Crowdin.Api
{
    public sealed class EditFolderParameters
    {
        [Required]
        public String Name { get; set; }

        public String NewName { get; set; }

        public String Title { get; set; }

        [Property("export_pattern")]
        public String ExportPattern { get; set; }

        public String Branch { get; set; }
    }
}