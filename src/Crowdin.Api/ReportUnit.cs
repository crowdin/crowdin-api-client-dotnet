namespace Crowdin.Api
{
    public enum ReportUnit
    {
        Strings,

        Words,

        Chars,

        [Property("chars_with_spaces")]
        CharsWithSpaces
    }
}
