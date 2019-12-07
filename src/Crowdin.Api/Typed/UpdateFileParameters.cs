using System;
using System.Collections.Generic;
using Crowdin.Api.Protocol;

namespace Crowdin.Api.Typed
{
    public sealed class UpdateFileParameters : FileParameters
    {
        [Property("new_names")]
        public IDictionary<String, String> NewNames { get; set; }

        [Property("update_option")]
        public UpdateFileOption? UpdateOption { get; set; }
    }
}