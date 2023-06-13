
using Crowdin.Api.Glossaries;
using Crowdin.Api.Storage;

namespace Crowdin.Api.Samples.Actions
{
    public partial class CrowdinActions
    {
        public async Task CreateGlossary(string filePath)
        {
            Glossary glossary = await _crowdinApiClient.Glossaries.AddGlossary(
                new AddGlossaryRequest
                {
                    Name = "My glossary",
                    LanguageId = "uk"
                });

            StorageResource storage = await _crowdinApiClient.AddStorage(filePath);

            GlossaryImportStatus importStatus = await _crowdinApiClient.Glossaries.ImportGlossary(
                glossary.Id,
                new ImportGlossaryRequest
                {
                    StorageId = storage.Id,
                    FirstLineContainsHeader = false,
                    Scheme = new Dictionary<string, int>
                    {
                        ["term_en"] = 0,
                        ["description_en"] = 1
                    }
                });

            // Wait until the import finished
            while (importStatus.Status is not "finished")
            {
                // Wait 5 seconds between check requests
                await Task.Delay(TimeSpan.FromSeconds(5));
                
                importStatus =
                    await _crowdinApiClient.Glossaries
                        .CheckGlossaryImportStatus(glossary.Id, importStatus.Identifier);
            }

            Console.WriteLine("Task is finished. Progress: {0}", importStatus.Progress);
        }
    }
}