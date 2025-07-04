
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    public interface ISourceFilesApiExecutor
    {
        #region Branches

        [Obsolete(MessageTexts.UseBranchesNamespace)]
        Task<ResponseList<Branch>> ListBranches(
            long projectId,
            string? name = null,
            int limit = 25,
            int offset = 0);

        [Obsolete(MessageTexts.UseBranchesNamespace)]
        Task<Branch> AddBranch(long projectId, AddBranchRequest request);

        [Obsolete(MessageTexts.UseBranchesNamespace)]
        Task<Branch> GetBranch(long projectId, long branchId);

        [Obsolete(MessageTexts.UseBranchesNamespace)]
        Task DeleteBranch(long projectId, long branchId);

        [Obsolete(MessageTexts.UseBranchesNamespace)]
        Task<Branch> EditBranch(long projectId, long branchId, IEnumerable<BranchPatch> patches);

        #endregion

        #region Directories

        Task<ResponseList<Directory>> ListDirectories(
            long projectId,
            int limit = 25,
            int offset = 0,
            long? branchId = null,
            long? directoryId = null,
            string? filter = null,
            object? recursion = null,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<Directory>> ListDirectories(long projectId, DirectoriesListParams @params);

        Task<Directory> AddDirectory(long projectId, AddDirectoryRequest request);

        Task<Directory> GetDirectory(long projectId, long directoryId);

        Task DeleteDirectory(long projectId, long directoryId);

        Task<Directory> EditDirectory(long projectId, long directoryId, IEnumerable<DirectoryPatch> patches);

        #endregion

        #region Files

        Task<ResponseList<T>> ListFiles<T>(long projectId,
            int limit = 25,
            int offset = 0,
            long? branchId = null,
            long? directoryId = null,
            string? filter = null,
            object? recursion = null,
            IEnumerable<SortingRule>? orderBy = null) where T : FileResourceBase;

        Task<ResponseList<T>> ListFiles<T>(long projectId, FilesListParams @params) where T : FileResourceBase;

        Task<File> AddFile(long projectId, AddFileRequest request);

        Task<TResponse> GetFile<TResponse>(long projectId, long fileId) where TResponse : FileInfoResource;

        Task<(File File, bool? IsModified)>
            UpdateOrRestoreFile(long projectId, long fileId, UpdateOrRestoreFileRequest request);

        Task DeleteFile(long projectId, long fileId);

        Task<File> EditFile(long projectId, long fileId, IEnumerable<FilePatch> patches);

        Task<DownloadLink> DownloadFile(long projectId, long fileId);

        Task<DownloadLink> DownloadFilePreview(long projectId, long fileId);

        Task<ResponseList<RevisionResource>> ListFileRevisions(long projectId, long fileId, int limit = 25, int offset = 0);

        Task<RevisionResource> GetFileRevision(long projectId, long fileId, long revisionId);

        #endregion

        #region Reviewed Source Files

        Task<ResponseList<ReviewedStringBuild>> ListReviewedSourceFilesBuilds(
            long projectId,
            long? branchId,
            int limit = 25,
            int offset = 0);

        Task<ReviewedStringBuild> BuildReviewedSourceFiles(long projectId, BuildReviewedSourceFilesRequest request);

        Task<ReviewedStringBuild> CheckReviewedSourceFilesBuildStatus(long projectId, long buildId);

        Task<DownloadLink> DownloadReviewedSourceFiles(long projectId, long buildId);

        #endregion
    }
}