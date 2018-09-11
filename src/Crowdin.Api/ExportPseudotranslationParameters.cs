using System;

namespace Crowdin.Api
{
    public sealed class ExportPseudotranslationParameters
    {
        public String Prefix { get; set; }

        public String Suffix { get; set; }

        [Property("length_transformation")]
        public Int32? LengthTransformation { get; set; }

        [Property("char_transformation")]
        public String CharTransformation { get; set; }
    }
}