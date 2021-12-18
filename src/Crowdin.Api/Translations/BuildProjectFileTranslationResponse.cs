
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public class BuildProjectFileTranslationResponse
    {
        public ResponseType Type { get; set; }
        
        public FileDownloadLink? Link { get; set; }

        public BuildProjectFileTranslationResponse(FileDownloadLink link)
        {
            Type = ResponseType.DownloadLink;
            Link = link;
        }

        public BuildProjectFileTranslationResponse(ResponseType type)
        {
            Type = type;
        }

        [PublicAPI]
        public enum ResponseType
        {
            DownloadLink,
            NoContent,
            FileNotModified
        }
    }
}