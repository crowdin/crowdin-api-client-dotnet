
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.SourceFiles
{
    public class SourceFilesApiExecutor : ISourceFilesApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public SourceFilesApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public SourceFilesApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }
        
        #region Branches

        /// <summary>
        /// List branches. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.branches.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.branches.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        [Obsolete(MessageTexts.UseBranchesNamespace)]
        public async Task<ResponseList<Branch>> ListBranches(
            long projectId, string? name = null, int limit = 25, int offset = 0)
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.AddParamIfPresent("name", name);

            string url = FormUrl_ProjectBranches(projectId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<Branch>(result.JsonObject);
        }
        
        /// <summary>
        /// Add branch. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.branches.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.branches.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        [Obsolete(MessageTexts.UseBranchesNamespace)]
        public async Task<Branch> AddBranch(long projectId, AddBranchRequest request)
        {
            string url = FormUrl_ProjectBranches(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<Branch>(result.JsonObject);
        }
        
        /// <summary>
        /// Get branch. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.branches.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.branches.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        [Obsolete(MessageTexts.UseBranchesNamespace)]
        public async Task<Branch> GetBranch(long projectId, long branchId)
        {
            string url = FormUrl_ProjectIdBranchId(projectId, branchId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Branch>(result.JsonObject);
        }

        /// <summary>
        /// Delete branch. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.branches.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.branches.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        [Obsolete(MessageTexts.UseBranchesNamespace)]
        public async Task DeleteBranch(long projectId, long branchId)
        {
            string url = FormUrl_ProjectIdBranchId(projectId, branchId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Branch {branchId} removal failed");
        }

        /// <summary>
        /// Edit branch. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.branches.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.branches.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        [Obsolete(MessageTexts.UseBranchesNamespace)]
        public async Task<Branch> EditBranch(long projectId, long branchId, IEnumerable<BranchPatch> patches)
        {
            string url = FormUrl_ProjectIdBranchId(projectId, branchId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Branch>(result.JsonObject);
        }
        
        #region Helper methods

        private static string FormUrl_ProjectBranches(long projectId)
        {
            return $"/projects/{projectId}/branches";
        }

        private static string FormUrl_ProjectIdBranchId(long projectId, long branchId)
        {
            return $"/projects/{projectId}/branches/{branchId}";
        }

        #endregion

        #endregion

        #region Directories

        /// <summary>
        /// List directories. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.directories.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.directories.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public Task<ResponseList<Directory>> ListDirectories(
            long projectId, int limit = 25, int offset = 0,
            long? branchId = null, long? directoryId = null,
            string? filter = null, object? recursion = null,
            IEnumerable<SortingRule>? orderBy = null)
        {
            return ListDirectories(projectId,
                new DirectoriesListParams(branchId, directoryId, filter, recursion, limit, offset, orderBy));
        }

        /// <summary>
        /// List directories. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.directories.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.directories.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<Directory>> ListDirectories(long projectId, DirectoriesListParams @params)
        {
            string url = FormUrl_ProjectDirectories(projectId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<Directory>(result.JsonObject);
        }

        /// <summary>
        /// Add directory. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.directories.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.directories.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Directory> AddDirectory(long projectId, AddDirectoryRequest request)
        {
            string url = FormUrl_ProjectDirectories(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<Directory>(result.JsonObject);
        }

        /// <summary>
        /// Get directory. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.directories.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.directories.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Directory> GetDirectory(long projectId, long directoryId)
        {
            string url = FormUrl_ProjectIdDirectoryId(projectId, directoryId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Directory>(result.JsonObject);
        }

        /// <summary>
        /// Delete directory. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.directories.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.directories.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteDirectory(long projectId, long directoryId)
        {
            string url = FormUrl_ProjectIdDirectoryId(projectId, directoryId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Directory {directoryId} removal failed");
        }

        /// <summary>
        /// Edit directory. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.directories.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.directories.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Directory> EditDirectory(long projectId, long directoryId, IEnumerable<DirectoryPatch> patches)
        {
            string url = FormUrl_ProjectIdDirectoryId(projectId, directoryId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Directory>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_ProjectDirectories(long projectId)
        {
            return $"/projects/{projectId}/directories";
        }

        private static string FormUrl_ProjectIdDirectoryId(long projectId, long directoryId)
        {
            return $"/projects/{projectId}/directories/{directoryId}";
        }

        #endregion

        #endregion

        #region Files
        
        /// <summary>
        /// List files. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.files.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.files.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public Task<ResponseList<T>> ListFiles<T>(long projectId,
            int limit = 25, int offset = 0,
            long? branchId = null, long? directoryId = null,
            string? filter = null, object? recursion = null,
            IEnumerable<SortingRule>? orderBy = null)
                where T : FileResourceBase // FileInfoCollectionResource, FileCollectionResource
        {
            return ListFiles<T>(projectId,
                new FilesListParams(branchId, directoryId, filter, recursion, limit, offset, orderBy));
        }
        
        /// <summary>
        /// List files. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.files.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.files.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<T>> ListFiles<T>(long projectId, FilesListParams @params)
            where T : FileResourceBase // FileInfoCollectionResource, FileCollectionResource
        {
            string url = FormUrl_ProjectFiles(projectId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<T>(result.JsonObject);
        }

        /// <summary>
        /// Add file. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.files.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.files.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<File> AddFile(long projectId, AddFileRequest request)
        {
            string url = FormUrl_ProjectFiles(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<File>(result.JsonObject);
        }

        /// <summary>
        /// Get file. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.files.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.files.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TResponse> GetFile<TResponse>(long projectId, long fileId)
            where TResponse : FileInfoResource // FileInfoResource, FileResource
        {
            string url = FormUrl_ProjectIdFileId(projectId, fileId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<TResponse>(result.JsonObject);
        }
        
        /// <summary>
        /// Update or Restore file. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.files.put">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.files.put">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<(File File, bool? IsModified)>
            UpdateOrRestoreFile(long projectId, long fileId, UpdateOrRestoreFileRequest request)
        {
            string url = FormUrl_ProjectIdFileId(projectId, fileId);
            CrowdinApiResult result = await _apiClient.SendPutRequest(url, request);

            bool? isModified = null;
            const string headerName = "Crowdin-API-Content-Status";
            if (result.Headers.Contains(headerName) &&
                result.Headers.TryGetValues(headerName, out IEnumerable<string>? values) &&
                values != null)
            {
                string headerValue = values.First();
                isModified = headerValue switch
                {
                    "modified" => true,
                    "not-modified" => false,
                    _ => null
                };
            }

            var file = _jsonParser.ParseResponseObject<File>(result.JsonObject);
            return (file, isModified);
        }

        /// <summary>
        /// Delete file. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.files.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.files.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteFile(long projectId, long fileId)
        {
            string url = FormUrl_ProjectIdFileId(projectId, fileId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"File {fileId} from project {projectId} removal failed");
        }

        /// <summary>
        /// Edit file. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.files.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.files.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<File> EditFile(long projectId, long fileId, IEnumerable<FilePatch> patches)
        {
            string url = FormUrl_ProjectIdFileId(projectId, fileId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<File>(result.JsonObject);
        }

        /// <summary>
        /// Download file. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.files.download.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.files.download.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<DownloadLink> DownloadFile(long projectId, long fileId)
        {
            var url = $"/projects/{projectId}/files/{fileId}/download";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<DownloadLink>(result.JsonObject);
        }
        
        /// <summary>
        /// Download file preview. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.files.preview.get">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.files.preview.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<DownloadLink> DownloadFilePreview(long projectId, long fileId)
        {
            var url = $"/projects/{projectId}/files/{fileId}/preview";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<DownloadLink>(result.JsonObject);
        }

        /// <summary>
        /// List file revisions. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.files.revisions.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.files.revisions.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<RevisionResource>> ListFileRevisions(
            long projectId, long fileId, int limit = 25, int offset = 0)
        {
            var url = $"/projects/{projectId}/files/{fileId}/revisions";
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<RevisionResource>(result.JsonObject);
        }

        /// <summary>
        /// Get file revision. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.files.revisions.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.files.revisions.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<RevisionResource> GetFileRevision(long projectId, long fileId, long revisionId)
        {
            var url = $"/projects/{projectId}/files/{fileId}/revisions/{revisionId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<RevisionResource>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_ProjectFiles(long projectId)
        {
            return $"/projects/{projectId}/files";
        }

        private static string FormUrl_ProjectIdFileId(long projectId, long fileId)
        {
            return $"/projects/{projectId}/files/{fileId}";
        }

        #endregion

        #endregion

        #region Reviewed Source Files

        /// <summary>
        /// List reviewed source files builds. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.strings.reviewed-builds.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<ReviewedStringBuild>> ListReviewedSourceFilesBuilds(
            long projectId,
            long? branchId,
            int limit = 25,
            int offset = 0)
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.AddParamIfPresent("branchId", branchId);
            
            var url = $"/projects/{projectId}/strings/reviewed-builds";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<ReviewedStringBuild>(result.JsonObject);
        }

        /// <summary>
        /// Build reviewed source files. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.strings.reviewed-builds.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ReviewedStringBuild> BuildReviewedSourceFiles(long projectId, BuildReviewedSourceFilesRequest request)
        {
            var url = $"/projects/{projectId}/strings/reviewed-builds";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<ReviewedStringBuild>(result.JsonObject);
        }

        /// <summary>
        /// Check reviewed source files build status. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.strings.reviewed-builds.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ReviewedStringBuild> CheckReviewedSourceFilesBuildStatus(long projectId, long buildId)
        {
            var url = $"/projects/{projectId}/strings/reviewed-builds/{buildId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<ReviewedStringBuild>(result.JsonObject);
        }

        /// <summary>
        /// Download reviewed source files. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.strings.reviewed-builds.download.download">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<DownloadLink> DownloadReviewedSourceFiles(long projectId, long buildId)
        {
            var url = $"/projects/{projectId}/strings/reviewed-builds/{buildId}/download";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<DownloadLink>(result.JsonObject);
        }

        #endregion

        #region File References

        /// <summary>
        /// List asset references. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.files.references.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.files.references.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<AssetReference>> ListAssetReferences(long projectId, long fileId, int limit = 25, int offset = 0)
        {
            string url = FormUrl_FileReferences(projectId, fileId);
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<AssetReference>(result.JsonObject);
        }

        /// <summary>
        /// Add asset reference. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.files.references.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.files.references.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AssetReference> AddAssetReference(long projectId, long fileId, AddAssetReferenceRequest request)
        {
            string url = FormUrl_FileReferences(projectId, fileId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<AssetReference>(result.JsonObject);
        }

        /// <summary>
        /// Get asset reference. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.files.references.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.files.references.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AssetReference> GetAssetReference(long projectId, long fileId, long referenceId)
        {
            string url = FormUrl_FileReferences_ReferenceId(projectId, fileId, referenceId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<AssetReference>(result.JsonObject);
        }

        /// <summary>
        /// Delete asset reference. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.files.references.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.files.references.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteAssetReference(long projectId, long fileId, long referenceId)
        {
            string url = FormUrl_FileReferences_ReferenceId(projectId, fileId, referenceId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"File reference {referenceId} removal failed");
        }

        #region Helper methods

        private static string FormUrl_FileReferences(long projectId, long fileId)
        {
            return $"/projects/{projectId}/files/{fileId}/references";
        }

        private static string FormUrl_FileReferences_ReferenceId(long projectId, long fileId, long referenceId)
        {
            return $"/projects/{projectId}/files/{fileId}/references/{referenceId}";
        }

        #endregion

        #endregion
    }
}