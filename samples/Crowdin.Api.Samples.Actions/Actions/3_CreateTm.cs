
using Crowdin.Api.Storage;
using Crowdin.Api.TranslationMemory;

using TmResource = Crowdin.Api.TranslationMemory.TranslationMemory;

namespace Crowdin.Api.Samples.Actions
{
    public partial class CrowdinActions
    {
        public async Task CreateTm(string filePath)
        {
            TmResource tm = await _crowdinApiClient.TranslationMemory.AddTm(
                new AddTmRequest
                {
                    Name = "My translation memory",
                    LanguageId = "uk"
                });

            StorageResource storage = await _crowdinApiClient.AddStorage(filePath);

            TmImportStatus importStatus = await _crowdinApiClient.TranslationMemory.ImportTm(
                tm.Id,
                new ImportTmRequest
                {
                    StorageId = storage.Id, // required
                    FirstLineContainsHeader = false, // optional
                    Scheme = new Dictionary<string, int> // optional
                    {
                        ["en"] = 0,
                        ["pl"] = 1,
                        ["uk"] = 2
                    }
                });

            // Wait until the import finished
            while (importStatus.Status is not OperationStatus.Finished)
            {
                // Wait 5 seconds between check requests
                await Task.Delay(TimeSpan.FromSeconds(5));
                
                importStatus =
                    await _crowdinApiClient.TranslationMemory
                        .CheckTmImportStatus(tm.Id, importStatus.Identifier);
            }

            Console.WriteLine("Task is finished. Progress: {0}", importStatus.Progress);
        }
    }
}