using System;
using System.Collections.Generic;
using Crowdin.Api.Protocol;

namespace Crowdin.Api.Typed
{
    public sealed class AddFileParameters : FileParameters
    {
        [Property("import_translations")]
        public Boolean? ImportTranslations { get; set; }

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