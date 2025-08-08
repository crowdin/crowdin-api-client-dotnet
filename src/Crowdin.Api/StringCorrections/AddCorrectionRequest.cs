using System.ComponentModel;

namespace Crowdin.Api.StringCorrections
{
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