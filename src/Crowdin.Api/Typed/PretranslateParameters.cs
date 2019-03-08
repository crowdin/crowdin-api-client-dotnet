using System;
using System.Collections.Generic;
using Crowdin.Api.Protocol;

namespace Crowdin.Api.Typed
{
    public class PretranslateParameters
    {
        [Required]
        public IEnumerable<String> Languages { get; set; }

        [Required]
        public IEnumerable<String> Files { get; set; }

        public String Method { get; set; }

        public String Engine { get; set; }

        [Property("approve_translated")]
        public Boolean? ApproveTranslated { get; set; }

        [Property("auto_approve_option")]
        public AutoApproveOption? AutoApprove { get; set; }

        [Property("import_duplicates")]
        public Boolean? ImportDuplicates { get; set; }

        [Property("apply_untranslated_strings_only")]
        public Boolean? UntranslatedStringsOnly { get; set; }

        [Property("perfect_match")]
        public Boolean? PerfectMatch { get; set; }
    }
}