using System;
using System.ComponentModel;
using Crowdin.Api.StringTranslations;
using JetBrains.Annotations;

namespace Crowdin.Api.StringCorrections
{
    [PublicAPI]
    public class Correction
    {
        [Description("id")]
        public int Id { get; set; }
       
        [Description("text")]
        public string Text { get; set; }

        [Description("pluralCategoryName")]
        public string PluralCategoryName { get; set; }

        [Description("user")]
        public User User { get; set; }

        [Description("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}