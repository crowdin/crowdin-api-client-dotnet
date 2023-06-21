
using JetBrains.Annotations;

namespace Crowdin.Api
{
    [PublicAPI]
    public static class ColumnType
    {
        public const string None = "none";
        
        public const string Identifier = "identifier";

        public const string SourcePhrase = "sourcePhrase";

        public const string SourceOrTranslation = "sourceOrTranslation";

        public const string Translation = "translation";

        public const string Context = "context";

        public const string MaxLength = "maxLength";

        public const string Labels = "labels";
    }
}