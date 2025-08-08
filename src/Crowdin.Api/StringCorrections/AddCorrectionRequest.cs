using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.StringCorrections
{
    [PublicAPI]
    public class AddCorrectionRequest
    {
        [Description("stringId")]
        public string StringId { get; set; }

        [Description("text")]
        public string Text { get; set; }

        [Description("pluralCategoryName")]
        public string PluralCategoryName { get; set; }
    }
}