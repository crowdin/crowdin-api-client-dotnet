using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static System.Web.HttpUtility;

namespace Crowdin.Api
{
    partial class Client
    {
        public Task<LanguageInfo[]> GetSupportedLanguages(CancellationToken cancellationToken = default)
        {
            return SendApiRequest<LanguageInfo[]>("supported-languages", null, cancellationToken: cancellationToken);
        }

        public Task<AccountProjectInfo[]> GetAccountProjects(AccountCredentials credentials, CancellationToken cancellationToken = default)
        {
            return SendApiRequest<AccountProjectInfo[]>("account/get-projects", credentials, payloadProperty: "projects", cancellationToken: cancellationToken);
        }

        public Task<HttpResponseMessage> CreateProject(AccountCredentials credentials, CreateProjectParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("account/create-project", credentials, parameters, cancellationToken);
        }

        public Task<ProjectInfo> GetProjectInfo(String projectId, Credentials credentials, CancellationToken cancellationToken = default)
        {
            return SendApiRequest<ProjectInfo>($"project/{UrlEncode(projectId)}/info", credentials, payloadProperty: null, cancellationToken: cancellationToken);
        }

        public Task<HttpResponseMessage> EditProject(String projectId, Credentials credentials, EditProjectParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/edit-project", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> DeleteProject(String projectId, Credentials credentials, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/delete-project", credentials, null, cancellationToken);
        }

        public Task<HttpResponseMessage> GetProjectStatus(String projectId, Credentials credentials, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/status", credentials, null, cancellationToken);
        }

        public Task<HttpResponseMessage> GetLanguageStatus(String projectId, Credentials credentials, GetLanguageStatusParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/language-status", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> AddFile(String projectId, Credentials credentials, AddFileParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/add-file", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> UpdateFile(String projectId, Credentials credentials, UpdateFileParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/update-file", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> ExportFile(String projectId, Credentials credentials, ExportFileParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/export-file", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> DeleteFile(String projectId, Credentials credentials, DeleteFileParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/delete-file", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> CreateFolder(String projectId, Credentials credentials, CreateFolderParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/add-directory", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> EditFolder(String projectId, Credentials credentials, EditFolderParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/change-directory", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> DeleteFolder(String projectId, Credentials credentials, DeleteFolderParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/delete-directory", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> UploadGlossary(String projectId, Credentials credentials, UploadGlossaryParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/upload-glossary", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> DownloadGlossary(String projectId, Credentials credentials, DownloadGlossaryParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/download-glossary", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> UploadTranslationMemory(String projectId, Credentials credentials, UploadTranslationMemoryParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/upload-tm", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> DownloadTranslationMemory(String projectId, Credentials credentials, DownloadTranslationMemoryParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/download-tm", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> Pretranslate(String projectId, Credentials credentials, PretranslateParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/pre-translate", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> UploadTranslation(String projectId, Credentials credentials, UploadTranslationParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/upload-translation", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> ExportTranslation(String projectId, Credentials credentials, ExportTranslationParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/export", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> GetTranslationExportStatus(String projectId, Credentials credentials, GetTranslationExportStatusParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/export-status", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> DownloadTranslation(String projectId, Credentials credentials, DownloadTranslationParameters parameters, CancellationToken cancellationToken = default)
        {
            String package = UrlEncode(parameters.Package);
            return SendApiRequest($"project/{UrlEncode(projectId)}/download/{package}.zip", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> ExportPseudotranslation(String projectId, Credentials credentials, ExportPseudotranslationParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/pseudo-export", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> DownloadPseudotranslation(String projectId, Credentials credentials, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/pseudo-download", credentials, null, cancellationToken);
        }

        public Task<HttpResponseMessage> GetProjectIssues(String projectId, Credentials credentials, GetProjectIssuesParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/issues", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> ExportCostsEstimationReport(String projectId, Credentials credentials, ExportCostsEstimationReportParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/reports/costs-estimation/export", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> DownloadCostsEstimationReport(String projectId, Credentials credentials, DownloadReportParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/reports/costs-estimation/download", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> ExportTranslationCostsReport(String projectId, Credentials credentials, ExportTranslationCostsReportParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/reports/translation-costs/export", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> DownloadTranslationCostsReport(String projectId, Credentials credentials, DownloadReportParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/reports/translation-costs/download", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> ExportTopMembersReport(String projectId, Credentials credentials, ExportTopMembersReportParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/reports/top-members/export", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> DownloadTopMembersReport(String projectId, Credentials credentials, DownloadReportParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest($"project/{UrlEncode(projectId)}/reports/top-members/download", credentials, parameters, cancellationToken);
        }
    }
}
