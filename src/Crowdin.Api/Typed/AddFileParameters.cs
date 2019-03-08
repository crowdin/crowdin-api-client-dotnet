using System;
using System.Collections.Generic;
using System.IO;
using Crowdin.Api.Protocol;

namespace Crowdin.Api.Typed
{
    public sealed class AddFileParameters
    {
        [Required]
        public IDictionary<String, FileInfo> Files { get; set; }

        public IDictionary<String, String> Titles { get; set; }

        [Property("export_patterns")]
        public IDictionary<String, String> ExportPatterns { get; set; }

        public String Type { get; set; }

        [Property("first_line_contains_header")]
        public Boolean? FirstLineContainsHeader { get; set; }

        [Property("import_translations")]
        public Boolean? ImportTranslations { get; set; }

        public String Scheme { get; set; }

        public String Branch { get; set; }

        [Property("translate_content")]
        public Boolean? TranslateContent { get; set; }

        [Property("translate_attributes")]
        public Boolean? TranslateAttributes { get; set; }

        [Property("translatable_elements")]
        public IEnumerable<String> TranslatableElements { get; set; }

        [Property("escape_quotes")]
        public EscapeQuotesOption EscapeQuotes { get; set; }
    }
}