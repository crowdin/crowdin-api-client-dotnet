using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Crowdin.Api
{
    partial class Client
    {
        public Task<LanguageInfo[]> GetSupportedLanguages(CancellationToken cancellationToken = default)
        {
            return SendApiRequest<LanguageInfo[]>("supported-languages", (AccountCredentials)null, cancellationToken: cancellationToken);
        }

        public Task<AccountProjectInfo[]> GetAccountProjects(AccountCredentials credentials, CancellationToken cancellationToken = default)
        {
            return SendApiRequest<AccountProjectInfo[]>("account/get-projects", credentials, payloadProperty: "projects", cancellationToken: cancellationToken);
        }

        public Task<HttpResponseMessage> CreateProject(AccountCredentials credentials, CreateProjectParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("account/create-project", credentials, parameters, cancellationToken);
        }

        public Task<ProjectInfo> GetProjectInfo(ProjectCredentials credentials, CancellationToken cancellationToken = default)
        {
            return SendApiRequest<ProjectInfo>("project/{ProjectID}/info", credentials, payloadProperty: null, cancellationToken: cancellationToken);
        }

        public Task<HttpResponseMessage> EditProject(ProjectCredentials credentials, EditProjectParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/edit-project", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> DeleteProject(ProjectCredentials credentials, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/delete-project", credentials, null, cancellationToken);
        }

        public Task<HttpResponseMessage> GetProjectStatus(ProjectCredentials credentials, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/status", credentials, null, cancellationToken);
        }

        public Task<HttpResponseMessage> GetLanguageStatus(ProjectCredentials credentials, GetLanguageStatusParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/language-status", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> AddFile(ProjectCredentials credentials, AddFileParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/add-file", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> UpdateFile(ProjectCredentials credentials, UpdateFileParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/update-file", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> ExportFile(ProjectCredentials credentials, ExportFileParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/export-file", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> DeleteFile(ProjectCredentials credentials, DeleteFileParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/delete-file", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> CreateFolder(ProjectCredentials credentials, CreateFolderParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/add-directory", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> EditFolder(ProjectCredentials credentials, EditFolderParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/change-directory", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> DeleteFolder(ProjectCredentials credentials, DeleteFolderParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/delete-directory", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> UploadGlossary(ProjectCredentials credentials, UploadGlossaryParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/upload-glossary", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> DownloadGlossary(ProjectCredentials credentials, DownloadGlossaryParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/download-glossary", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> UploadTranslationMemory(ProjectCredentials credentials, UploadTranslationMemoryParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/upload-tm", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> DownloadTranslationMemory(ProjectCredentials credentials, DownloadTranslationMemoryParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/download-tm", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> Pretranslate(ProjectCredentials credentials, PretranslateParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/pre-translate", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> UploadTranslation(ProjectCredentials credentials, UploadTranslationParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/upload-translation", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> ExportTranslation(ProjectCredentials credentials, ExportTranslationParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/export", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> DownloadTranslation(ProjectCredentials credentials, DownloadTranslationParameters parameters, CancellationToken cancellationToken = default)
        {
            String package = HttpUtility.UrlEncode(parameters.Package);
            return SendApiRequest($"project/{{ProjectID}}/download/{package}.zip", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> ExportPseudotranslation(ProjectCredentials credentials, ExportPseudotranslationParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/pseudo-export", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> DownloadPseudotranslation(ProjectCredentials credentials, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/pseudo-download", credentials, null, cancellationToken);
        }

        public Task<HttpResponseMessage> GetProjectIssues(ProjectCredentials credentials, GetProjectIssuesParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/issues", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> ExportCostsEstimationReport(ProjectCredentials credentials, ExportCostsEstimationReportParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/reports/costs-estimation/export", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> DownloadCostsEstimationReport(ProjectCredentials credentials, DownloadReportParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/reports/costs-estimation/download", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> ExportTranslationCostsReport(ProjectCredentials credentials, ExportTranslationCostsReportParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/reports/translation-costs/export", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> DownloadTranslationCostsReport(ProjectCredentials credentials, DownloadReportParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/reports/translation-costs/download", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> ExportTopMembersReport(ProjectCredentials credentials, ExportTopMembersReportParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/reports/top-members/export", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> DownloadTopMembersReport(ProjectCredentials credentials, DownloadReportParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/reports/top-members/download", credentials, parameters, cancellationToken);
        }
    }
}
