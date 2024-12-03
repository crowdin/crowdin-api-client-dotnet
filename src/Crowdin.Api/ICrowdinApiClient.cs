
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Abstractions;
using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api
{
    [PublicAPI]
    public interface ICrowdinApiClient
    {
        IJsonParser DefaultJsonParser { get; }

        #region Public API
        
        IBundlesApiExecutor Bundles { get; }
        
        IDictionariesApiExecutor Dictionaries { get; }
        
        IDistributionsApiExecutor Distributions { get; }
        
        IGlossariesApiExecutor Glossaries { get; }
        
        IIssuesApiExecutor Issues { get; }
        
        ILabelsApiExecutor Labels { get; }
        
        ILanguagesApiExecutor Languages { get; }
        
        IMachineTranslationEnginesApiExecutor MachineTranslationEngines { get; }
        
        IProjectsGroupsApiExecutor ProjectsGroups { get; }
        
        IReportsApiExecutor Reports { get; }
        
        IScreenshotsApiExecutor Screenshots { get; }
        
        ISecurityLogsApiExecutor SecurityLogs { get; }
        
        ISourceFilesApiExecutor SourceFiles { get; }
        
        ISourceStringsApiExecutor SourceStrings { get; }
        
        IStorageApiExecutor Storage { get; }
        
        IStringCommentsApiExecutor StringComments { get; }
        
        IStringTranslationsApiExecutor StringTranslations { get; }
        
        ITasksApiExecutor Tasks { get; }
        
        ITeamsApiExecutor Teams { get; }
        
        ITranslationMemoryApiExecutor TranslationMemory { get; }
        
        ITranslationsApiExecutor Translations { get; }
        
        ITranslationStatusApiExecutor TranslationStatus { get; }
        
        IUsersApiExecutor Users { get; }
        
        IVendorsApiExecutor Vendors { get; }
        
        IWebhooksApiExecutor Webhooks { get; }
        
        IOrganizationWebhooksApiExecutor OrganizationWebhooks { get; }

        IWorkflowsApiExecutor Workflows { get; }

        IApplicationsApiExecutor Applications { get; }

        #endregion

        #region Internal methods

        internal Task<CrowdinApiResult> SendGetRequest(string subUrl, IDictionary<string, string>? queryParams = null);

        internal Task<CrowdinApiResult> SendPostRequest(string subUrl, object? body = null, IDictionary<string, string>? extraHeaders = null);

        internal Task<CrowdinApiResult> SendPutRequest(string subUrl, object? body = null);

        internal Task<CrowdinApiResult> SendPatchRequest(string subUrl, IEnumerable<PatchEntry> body, IDictionary<string, string>? queryParams = null);
        
        internal Task<CrowdinApiResult> SendPatchRequest(string subUrl, object body, IDictionary<string, string>? queryParams = null);

        internal Task<HttpStatusCode> SendDeleteRequest(string subUrl, IDictionary<string, string>? queryParams = null);
        
        internal Task<CrowdinApiResult> SendDeleteRequest_FullResult(string subUrl, IDictionary<string, string>? queryParams = null);

        internal Task<CrowdinApiResult> UploadFile(string subUrl, string filename, Stream fileStream);

        #endregion
    }
}