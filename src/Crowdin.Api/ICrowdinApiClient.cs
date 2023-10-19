
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using JetBrains.Annotations;

using Crowdin.Api.Applications;
using Crowdin.Api.Bundles;
using Crowdin.Api.Core;
using Crowdin.Api.Dictionaries;
using Crowdin.Api.Distributions;
using Crowdin.Api.Glossaries;
using Crowdin.Api.Issues;
using Crowdin.Api.Labels;
using Crowdin.Api.Languages;
using Crowdin.Api.MachineTranslationEngines;
using Crowdin.Api.ProjectsGroups;
using Crowdin.Api.Reports;
using Crowdin.Api.Screenshots;
using Crowdin.Api.SourceFiles;
using Crowdin.Api.SourceStrings;
using Crowdin.Api.Storage;
using Crowdin.Api.StringComments;
using Crowdin.Api.StringTranslations;
using Crowdin.Api.Tasks;
using Crowdin.Api.Teams;
using Crowdin.Api.TranslationMemory;
using Crowdin.Api.Translations;
using Crowdin.Api.TranslationStatus;
using Crowdin.Api.Users;
using Crowdin.Api.Vendors;
using Crowdin.Api.Webhooks;

#nullable enable

namespace Crowdin.Api
{
    [PublicAPI]
    public interface ICrowdinApiClient
    {
        IJsonParser DefaultJsonParser { get; }

        #region Public API
        
        BundlesApiExecutor Bundles { get; }
        
        DictionariesApiExecutor Dictionaries { get; }
        
        DistributionsApiExecutor Distributions { get; }
        
        GlossariesApiExecutor Glossaries { get; }
        
        IssuesApiExecutor Issues { get; }
        
        LabelsApiExecutor Labels { get; }
        
        LanguagesApiExecutor Languages { get; }
        
        MachineTranslationEnginesApiExecutor MachineTranslationEngines { get; }
        
        ProjectsGroupsApiExecutor ProjectsGroups { get; }
        
        ReportsApiExecutor Reports { get; }
        
        ScreenshotsApiExecutor Screenshots { get; }
        
        SourceFilesApiExecutor SourceFiles { get; }
        
        SourceStringsApiExecutor SourceStrings { get; }
        
        StorageApiExecutor Storage { get; }
        
        StringCommentsApiExecutor StringComments { get; }
        
        StringTranslationsApiExecutor StringTranslations { get; }
        
        TasksApiExecutor Tasks { get; }
        
        TeamsApiExecutor Teams { get; }
        
        TranslationMemoryApiExecutor TranslationMemory { get; }
        
        TranslationsApiExecutor Translations { get; }
        
        TranslationStatusApiExecutor TranslationStatus { get; }
        
        UsersApiExecutor Users { get; }
        
        VendorsApiExecutor Vendors { get; }
        
        WebhooksApiExecutor Webhooks { get; }

        ApplicationsApiExecutor Applications { get; }

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