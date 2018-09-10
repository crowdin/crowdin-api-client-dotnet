using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Crowdin.Api
{
    partial class Client
    {
        public Task<HttpResponseMessage> GetSupportedLanguages(CancellationToken cancellationToken = default)
        {
            return SendApiRequest("supported-languages", (AccountCredentials)null, null, cancellationToken);
        }

        public Task<HttpResponseMessage> GetAccountProjects(AccountCredentials credentials, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("account/get-projects", credentials, null, cancellationToken);
        }

        public Task<HttpResponseMessage> CreateProject(AccountCredentials credentials, CreateProjectParameters parameters, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("account/create-project", credentials, parameters, cancellationToken);
        }

        public Task<HttpResponseMessage> GetProjectInfo(ProjectCredentials credentials, CancellationToken cancellationToken = default)
        {
            return SendApiRequest("project/{ProjectID}/info", credentials, null, cancellationToken);
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
    }
}
