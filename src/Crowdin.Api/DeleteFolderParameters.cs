using System;
using Crowdin.Api.Protocol;

namespace Crowdin.Api
{
    public sealed class DeleteFolderParameters
    {
        [Required]
        public String Name { get; set; }

        public String Branch { get; set; }
    }
}