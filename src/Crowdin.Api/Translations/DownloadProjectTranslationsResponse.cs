
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public class DownloadProjectTranslationsResponse
    {
        public ResponseType Type { get; set; }
        
        public DownloadLink? Link { get; set; }
        
        public ProjectBuild? Build { get; set; }

        public DownloadProjectTranslationsResponse(DownloadLink link)
        {
            Type = ResponseType.DownloadLink;
            Link = link;
        }

        public DownloadProjectTranslationsResponse(ProjectBuild build)
        {
            Type = ResponseType.ProjectBuild;
            Build = build;
        }

        [PublicAPI]
        public enum ResponseType
        {
            DownloadLink,
            ProjectBuild
        }
    }
}