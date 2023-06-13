
using Crowdin.Api.SourceFiles;
using Crowdin.Api.Storage;

using File = Crowdin.Api.SourceFiles.File;

namespace Crowdin.Api.Samples.Actions
{
    public partial class CrowdinActions
    {
        public async Task UpdateFile(int projectId, string filePath1, string filePath2)
        {
            #region Add original file

            StorageResource storage1 = await _crowdinApiClient.AddStorage(filePath1);

            File firstFile = await _crowdinApiClient.SourceFiles.AddFile(projectId,
                new AddFileRequest
                {
                    StorageId = storage1.Id,
                    ImportOptions = new SpreadsheetFileImportOptions
                    {
                        FirstLineContainsHeader = true,
                        Scheme = new Dictionary<string, int>
                        {
                            ["identifier"] = 1,
                            ["sourcePhrase"] = 2,
                            ["translation"] = 3
                        }
                    }
                });

            #endregion

            #region Replace the first file

            StorageResource storage2 = await _crowdinApiClient.AddStorage(filePath2);

            (File secondFile, bool? isModified) = await _crowdinApiClient.SourceFiles.UpdateOrRestoreFile(
                projectId,
                firstFile.Id,
                new ReplaceFileRequest
                {
                    StorageId = storage2.Id, // required
                    UpdateOption = FileUpdateOption.KeepTranslationsAndApprovals // optional
                });

            #endregion

            Console.WriteLine("IsModified: {0}", isModified);
            Console.WriteLine("File {0} replaced with {1}", firstFile.Id, secondFile.Id);
        }
    }
}