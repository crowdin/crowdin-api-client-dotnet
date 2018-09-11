using System;
using System.Collections.Generic;
using System.IO;

namespace Crowdin.Api
{
    public sealed class UploadTranslationParameters
    {
        [Required]
        public IDictionary<String, FileInfo> Files { get; set; }

        [Required]
        public String Language { get; set; }

        [Property("import_duplicates")]
        public Boolean? ImportDuplicates { get; set; }

        [Property("import_eq_suggestions")]
        public Boolean? ImportIfEqualToSource { get; set; }

        [Property("auto_approve_imported")]
        public Boolean? AutoApproveImported { get; set; }

        public String Format { get; set; }

        public String Branch { get; set; }
    }
}