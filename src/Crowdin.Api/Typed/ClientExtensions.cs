using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using static System.Web.HttpUtility;

namespace Crowdin.Api.Typed
{
    public static class ClientExtensions
    {
        static ClientExtensions()
        {
            _errorSerializer = new XmlSerializer(typeof(Error));
        }

        public static async Task<T> SendApiRequest<T>(this IClient client, String url, Credentials credentials, Object body = null, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = await client.SendApiRequest(url, credentials, body, cancellationToken: cancellationToken);
            T result = await ReadApiResponse<T>(response, cancellationToken);
            return result;
        }

        public static async Task<ReadOnlyCollection<LanguageInfo>> GetSupportedLanguages(this IClient client, CancellationToken cancellationToken = default)
        {
            SupportedLanguages supportedLanguages = await client.SendApiRequest<SupportedLanguages>("supported-languages", null, cancellationToken: cancellationToken);
            return supportedLanguages.Languages;
        }

        public static async Task<ReadOnlyCollection<AccountProjectInfo>> GetAccountProjects(this IClient client, AccountCredentials credentials, CancellationToken cancellationToken = default)
        {
            AccountProjects accountProjects = await client.SendApiRequest<AccountProjects>("account/get-projects", credentials, cancellationToken: cancellationToken);
            return accountProjects.Projects;
        }

        public static Task<HttpResponseMessage> CreateProject(this IClient client, AccountCredentials credentials, CreateProjectParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest("account/create-project", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<ProjectInfo> GetProjectInfo(this IClient client, String projectId, Credentials credentials, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest<ProjectInfo>($"project/{UrlEncode(projectId)}/info", credentials, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> EditProject(this IClient client, String projectId, Credentials credentials, EditProjectParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/edit-project", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> DeleteProject(this IClient client, String projectId, Credentials credentials, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/delete-project", credentials, cancellationToken: cancellationToken);
        }

        public static async Task<ReadOnlyCollection<TargetLanguageStatus>> GetProjectStatus(this IClient client, String projectId, Credentials credentials, CancellationToken cancellationToken = default)
        {
            ProjectTranslationStatus projectTranslationStatus = await client.SendApiRequest<ProjectTranslationStatus>($"project/{UrlEncode(projectId)}/status", credentials, cancellationToken: cancellationToken);
            return projectTranslationStatus.Languages;
        }

        public static Task<LanguageTranslationStatus> GetLanguageStatus(this IClient client, String projectId, Credentials credentials, GetLanguageStatusParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest<LanguageTranslationStatus>($"project/{UrlEncode(projectId)}/language-status", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> AddFile(this IClient client, String projectId, Credentials credentials, AddFileParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/add-file", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> UpdateFile(this IClient client, String projectId, Credentials credentials, UpdateFileParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/update-file", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> ExportFile(this IClient client, String projectId, Credentials credentials, ExportFileParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/export-file", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> DeleteFile(this IClient client, String projectId, Credentials credentials, DeleteFileParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/delete-file", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> CreateFolder(this IClient client, String projectId, Credentials credentials, CreateFolderParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/add-directory", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> EditFolder(this IClient client, String projectId, Credentials credentials, EditFolderParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/change-directory", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> DeleteFolder(this IClient client, String projectId, Credentials credentials, DeleteFolderParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/delete-directory", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> UploadGlossary(this IClient client, String projectId, Credentials credentials, UploadGlossaryParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/upload-glossary", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> DownloadGlossary(this IClient client, String projectId, Credentials credentials, DownloadGlossaryParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/download-glossary", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> UploadTranslationMemory(this IClient client, String projectId, Credentials credentials, UploadTranslationMemoryParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/upload-tm", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> DownloadTranslationMemory(this IClient client, String projectId, Credentials credentials, DownloadTranslationMemoryParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/download-tm", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> Pretranslate(this IClient client, String projectId, Credentials credentials, PretranslateParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/pre-translate", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> UploadTranslation(this IClient client, String projectId, Credentials credentials, UploadTranslationParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/upload-translation", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> ExportTranslation(this IClient client, String projectId, Credentials credentials, ExportTranslationParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/export", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> GetTranslationExportStatus(this IClient client, String projectId, Credentials credentials, GetTranslationExportStatusParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/export-status", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> DownloadTranslation(this IClient client, String projectId, Credentials credentials, DownloadTranslationParameters parameters, CancellationToken cancellationToken = default)
        {
            String package = UrlEncode(parameters.Package);
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/download/{package}.zip", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> ExportPseudotranslation(this IClient client, String projectId, Credentials credentials, ExportPseudotranslationParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/pseudo-export", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> DownloadPseudotranslation(this IClient client, String projectId, Credentials credentials, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/pseudo-download", credentials, null, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> GetProjectIssues(this IClient client, String projectId, Credentials credentials, GetProjectIssuesParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/issues", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> ExportCostsEstimationReport(this IClient client, String projectId, Credentials credentials, ExportCostsEstimationReportParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/reports/costs-estimation/export", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> DownloadCostsEstimationReport(this IClient client, String projectId, Credentials credentials, DownloadReportParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/reports/costs-estimation/download", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> ExportTranslationCostsReport(this IClient client, String projectId, Credentials credentials, ExportTranslationCostsReportParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/reports/translation-costs/export", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> DownloadTranslationCostsReport(this IClient client, String projectId, Credentials credentials, DownloadReportParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/reports/translation-costs/download", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> ExportTopMembersReport(this IClient client, String projectId, Credentials credentials, ExportTopMembersReportParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/reports/top-members/export", credentials, parameters, cancellationToken: cancellationToken);
        }

        public static Task<HttpResponseMessage> DownloadTopMembersReport(this IClient client, String projectId, Credentials credentials, DownloadReportParameters parameters, CancellationToken cancellationToken = default)
        {
            return client.SendApiRequest($"project/{UrlEncode(projectId)}/reports/top-members/download", credentials, parameters, cancellationToken: cancellationToken);
        }

        private static async Task<T> ReadApiResponse<T>(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            if (response.Content.Headers.ContentType.MediaType != "text/xml")
            {
                throw new InvalidOperationException("Only XML content is acceptable.");
            }
            using (Stream xml = await response.Content.ReadAsStreamAsync())
            {
                EnsureSucess(xml);
                using (XmlReader xmlReader = XmlReader.Create(xml))
                {
                    var xmlSerializer = new XmlSerializer(typeof(T));
                    var result = (T)xmlSerializer.Deserialize(xmlReader);
                    return result;
                }
            }
        }

        private static void EnsureSucess(Stream response)
        {
            using (XmlReader xmlReader = XmlReader.Create(response))
            {
                if (_errorSerializer.CanDeserialize(xmlReader))
                {
                    var error = (Error)_errorSerializer.Deserialize(xmlReader);
                    throw new CrowdinException(error.Message, error.Code);
                }
                response.Seek(0, SeekOrigin.Begin);
            }
        }

        private static readonly XmlSerializer _errorSerializer;
    }
}
