
using Crowdin.Api.SourceFiles;
using Crowdin.Api.Storage;
using Crowdin.Api.Translations;

using File = Crowdin.Api.SourceFiles.File;

namespace Crowdin.Api.Samples.Actions
{
    public partial class CrowdinActions
    {
        public async Task PreTranslateProject(string filePath)
        {
            const int projectId = 1;

            StorageResource storage = await _crowdinApiClient.AddStorage(filePath);
            
            File file = await _crowdinApiClient.SourceFiles.AddFile(projectId,
                new AddFileRequest
                {
                    StorageId = storage.Id,
                    ImportOptions = new SpreadsheetFileImportOptions
                    {
                        FirstLineContainsHeader = true,
                        Scheme = new Dictionary<string, int>
                        {
                            [ColumnType.Identifier] = 1,
                            [ColumnType.SourcePhrase] = 2,
                            [ColumnType.Translation] = 3
                        }
                    }
                });

            PreTranslation preTranslation = await _crowdinApiClient.Translations.ApplyPreTranslation(
                projectId,
                new ApplyPreTranslationRequest
                {
                    LanguageIds = new[] { "en", "uk", "es" },
                    FileIds = new[] { file.Id },
                    AutoApproveOption = AutoApproveOption.PerfectMatchOnly, // optional
                    FallbackLanguages = new Dictionary<string, string[]>    // optional
                    {
                        ["es"] = new []{ "uk", "en" }
                    }
                });

            // Wait until the pre-translation finished
            while (preTranslation.Status is not BuildStatus.Finished)
            {
                // Wait 5 seconds between check requests
                await Task.Delay(TimeSpan.FromSeconds(5));
                
                preTranslation =
                    await _crowdinApiClient.Translations
                        .GetPreTranslationStatus(projectId, preTranslation.Identifier);
            }

            Console.WriteLine("Task is finished. Progress: {0}", preTranslation.Progress);
        }
    }
}