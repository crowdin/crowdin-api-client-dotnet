using System;
using Crowdin.Api.Protocol;

namespace Crowdin.Api.Typed
{
    public sealed class DeleteFolderParameters
    {
        [Required]
        public String Name { get; set; }

        public String Branch { get; set; }
    }
}