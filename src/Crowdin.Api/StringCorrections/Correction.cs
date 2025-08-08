using System;
using System.ComponentModel;

namespace Crowdin.Api.StringCorrections
{
    public class Correction
    {
        [Description("id")]
        public int Id { get; set; }
       
        [Description("text")]
        public string Text { get; set; }

        [Description("pluralCategoryName")]
        public string PluralCategoryName { get; set; }

        [Description("user")]
        public CorrectionUser User { get; set; }

        [Description("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}