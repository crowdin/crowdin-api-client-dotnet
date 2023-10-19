
using Crowdin.Api.Translations;

namespace Crowdin.Api.Samples.Actions
{
    public partial class CrowdinActions
    {
        public async Task DownloadTranslations(int projectId)
        {
            ProjectBuild build =
                await _crowdinApiClient.Translations.BuildProjectTranslation(
                    projectId,
                    new TranslationCreateProjectBuildForm
                    {
                        TargetLanguageIds = new[] { "uk" },
                        SkipUntranslatedFiles = true,
                        SkipUntranslatedStrings = true,
                        ExportApprovedOnly = false
                    });

            // Wait until the report generation finished
            while (build.Status is not BuildStatus.Finished)
            {
                // Wait 5 seconds between check requests
                await Task.Delay(TimeSpan.FromSeconds(5));
                
                build = await _crowdinApiClient.Translations.CheckProjectBuildStatus(projectId, build.Id);
            }
            
            // Task finished -> download translations
            DownloadProjectTranslationsResponse downloadProjectTranslationsResponse =
                await _crowdinApiClient.Translations.DownloadProjectTranslations(projectId, build.Id);
            
            // Do actions according to response type
            switch (downloadProjectTranslationsResponse.Type)
            {
                case DownloadProjectTranslationsResponse.ResponseType.DownloadLink:
                {
                    DownloadLink? result = downloadProjectTranslationsResponse.Link;
                    ArgumentNullException.ThrowIfNull(result);

                    Console.WriteLine("Project translations are ready to download");
                    Console.WriteLine("Download link: {0} (expire in {1})", result.Url, result.ExpireIn);
                    break;
                }

                case DownloadProjectTranslationsResponse.ResponseType.ProjectBuild:
                {
                    ProjectBuild? result = downloadProjectTranslationsResponse.Build;
                    ArgumentNullException.ThrowIfNull(result);

                    Console.WriteLine("Project translations are still building");
                    Console.WriteLine("Status: {0}", Enum.GetName(result.Status));
                    break;
                }
            }
        }
    }
}