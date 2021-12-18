
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.SourceFiles
{
    public class SourceFilesApiExecutor
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

        [PublicAPI]
        public async Task<ResponseList<Branch>> ListBranches(
            int projectId, string? name = null, int limit = 25, int offset = 0)
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.AddParamIfPresent("name", name);

            string url = FormUrl_ProjectBranches(projectId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<Branch>(result.JsonObject);
        }
        
        [PublicAPI]
        public async Task<Branch> AddBranch(int projectId, AddBranchRequest request)
        {
            string url = FormUrl_ProjectBranches(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<Branch>(result.JsonObject);
        }
        
        [PublicAPI]
        public async Task<Branch> GetBranch(int projectId, int branchId)
        {
            string url = FormUrl_ProjectIdBranchId(projectId, branchId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Branch>(result.JsonObject);
        }

        [PublicAPI]
        public async Task DeleteBranch(int projectId, int branchId)
        {
            string url = FormUrl_ProjectIdBranchId(projectId, branchId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Branch {branchId} removal failed");
        }

        [PublicAPI]
        public async Task<Branch> EditBranch(int projectId, int branchId, IEnumerable<BranchPatch> patches)
        {
            string url = FormUrl_ProjectIdBranchId(projectId, branchId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Branch>(result.JsonObject);
        }
        
        #region Helper methods

        private static string FormUrl_ProjectBranches(int projectId)
        {
            return $"/projects/{projectId}/branches";
        }

        private static string FormUrl_ProjectIdBranchId(int projectId, int branchId)
        {
            return $"/projects/{projectId}/branches/{branchId}";
        }

        #endregion

        #endregion

        #region Directories

        [PublicAPI]
        public Task<ResponseList<Directory>> ListDirectories(
            int projectId, int limit = 25, int offset = 0,
            int? branchId = null, int? directoryId = null,
            string? filter = null, object? recursion = null)
        {
            return ListDirectories(projectId,
                new DirectoriesListParams(branchId, directoryId, filter, recursion, limit, offset));
        }

        [PublicAPI]
        public async Task<ResponseList<Directory>> ListDirectories(int projectId, DirectoriesListParams @params)
        {
            string url = FormUrl_ProjectDirectories(projectId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<Directory>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<Directory> AddDirectory(int projectId, AddDirectoryRequest request)
        {
            string url = FormUrl_ProjectDirectories(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<Directory>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<Directory> GetDirectory(int projectId, int directoryId)
        {
            string url = FormUrl_ProjectIdDirectoryId(projectId, directoryId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Directory>(result.JsonObject);
        }

        [PublicAPI]
        public async Task DeleteDirectory(int projectId, int directoryId)
        {
            string url = FormUrl_ProjectIdDirectoryId(projectId, directoryId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Directory {directoryId} removal failed");
        }

        [PublicAPI]
        public async Task<Directory> EditDirectory(int projectId, int directoryId, IEnumerable<DirectoryPatch> patches)
        {
            string url = FormUrl_ProjectIdDirectoryId(projectId, directoryId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Directory>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_ProjectDirectories(int projectId)
        {
            return $"/projects/{projectId}/directories";
        }

        private static string FormUrl_ProjectIdDirectoryId(int projectId, int directoryId)
        {
            return $"/projects/{projectId}/directories/{directoryId}";
        }

        #endregion

        #endregion

        #region Files
        
        [PublicAPI]
        public Task<ResponseList<T>> ListFiles<T>(int projectId,
            int limit = 25, int offset = 0,
            int? branchId = null, int? directoryId = null,
            string? filter = null, object? recursion = null)
                where T : FileResourceBase // FileInfoCollectionResource, FileCollectionResource
        {
            return ListFiles<T>(projectId,
                new FilesListParams(branchId, directoryId, filter, recursion, limit, offset));
        }
        
        [PublicAPI]
        public async Task<ResponseList<T>> ListFiles<T>(int projectId, FilesListParams @params)
            where T : FileResourceBase // FileInfoCollectionResource, FileCollectionResource
        {
            string url = FormUrl_ProjectFiles(projectId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<T>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<File> AddFile(int projectId, AddFileRequest request)
        {
            string url = FormUrl_ProjectFiles(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<File>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<TResponse> GetFile<TResponse>(int projectId, int fileId)
            where TResponse : FileInfoResource // FileInfoResource, FileResource
        {
            string url = FormUrl_ProjectIdFileId(projectId, fileId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<TResponse>(result.JsonObject);
        }
        
        [PublicAPI]
        public async Task<(File File, bool? IsModified)>
            UpdateOrRestoreFile(int projectId, int fileId, UpdateOrRestoreFileRequest request)
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

        [PublicAPI]
        public async Task DeleteFile(int projectId, int fileId)
        {
            string url = FormUrl_ProjectIdFileId(projectId, fileId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"File {fileId} from project {projectId} removal failed");
        }

        [PublicAPI]
        public async Task<File> EditFile(int projectId, int fileId, IEnumerable<FilePatch> patches)
        {
            string url = FormUrl_ProjectIdFileId(projectId, fileId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<File>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<DownloadLink> DownloadFile(int projectId, int fileId)
        {
            var url = $"/projects/{projectId}/files/{fileId}/download";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<DownloadLink>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<ResponseList<RevisionResource>> ListFileRevisions(
            int projectId, int fileId, int limit = 25, int offset = 0)
        {
            var url = $"/projects/{projectId}/files/{fileId}/revisions";
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<RevisionResource>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<RevisionResource> GetFileRevision(int projectId, int fileId, int revisionId)
        {
            var url = $"/projects/{projectId}/files/{fileId}/revisions/{revisionId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<RevisionResource>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_ProjectFiles(int projectId)
        {
            return $"/projects/{projectId}/files";
        }

        private static string FormUrl_ProjectIdFileId(int projectId, int fileId)
        {
            return $"/projects/{projectId}/files/{fileId}";
        }

        #endregion

        #endregion

        #region Reviewed Source Files

        [PublicAPI]
        public async Task<ResponseList<ReviewedStringBuild>> ListReviewedSourceFilesBuilds(
            int projectId, int? branchId, int limit = 25, int offset = 0)
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.AddParamIfPresent("branchId", branchId);
            
            var url = $"/projects/{projectId}/strings/reviewed-builds";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<ReviewedStringBuild>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<ReviewedStringBuild> BuildReviewedSourceFiles(int projectId, BuildReviewedSourceFilesRequest request)
        {
            var url = $"/projects/{projectId}/strings/reviewed-builds";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<ReviewedStringBuild>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<ReviewedStringBuild> CheckReviewedSourceFilesBuildStatus(int projectId, int buildId)
        {
            var url = $"/projects/{projectId}/strings/reviewed-builds/{buildId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<ReviewedStringBuild>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<DownloadLink> DownloadReviewedSourceFiles(int projectId, int buildId)
        {
            var url = $"/projects/{projectId}/strings/reviewed-builds/{buildId}/download";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<DownloadLink>(result.JsonObject);
        }

        #endregion
    }
}