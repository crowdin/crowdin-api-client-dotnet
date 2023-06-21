
using Crowdin.Api.SourceFiles;
using Crowdin.Api.Storage;

using File = Crowdin.Api.SourceFiles.File;

namespace Crowdin.Api.Samples.Actions
{
    public partial class CrowdinActions
    {
        public async Task CreateFile(int projectId, string filePath)
        {
            StorageResource storage = await _crowdinApiClient.AddStorage(filePath);

            File file = await _crowdinApiClient.SourceFiles.AddFile(projectId,
                new AddFileRequest
                {
                    StorageId = storage.Id,
                    Name = storage.FileName,
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

            Console.WriteLine("File added. ID: {0}", file.Id);
        }
    }
}