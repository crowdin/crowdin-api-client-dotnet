
Console.WriteLine("This is a Crowdin Samples project");

const string accessToken = "insert token here";

var actions = new CrowdinActions(accessToken);

// Available actions
// Uncomment needed and add arguments

// await actions.CreateFile(projectId, filePath);
// await actions.UpdateFile(projectId, filePath1, filePath2);
// await actions.CreateTm(filePath);
// await actions.CreateGlossary(filePath);
// await actions.PreTranslateProject(filePath);
// await actions.DownloadTranslations(projectId);
// await actions.GenerateReport(projectId, directoryId, fileId);