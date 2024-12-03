
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Core;
using Crowdin.Api.SourceFiles;

#nullable enable

namespace Crowdin.Api.Abstractions
{
    [PublicAPI]
    public interface ISourceFilesApiExecutor
    {
        #region Branches

        [Obsolete(MessageTexts.UseBranchesNamespace)]
        Task<ResponseList<Branch>> ListBranches(
            int projectId,
            string? name = null,
            int limit = 25,
            int offset = 0);

        [Obsolete(MessageTexts.UseBranchesNamespace)]
        Task<Branch> AddBranch(int projectId, AddBranchRequest request);

        [Obsolete(MessageTexts.UseBranchesNamespace)]
        Task<Branch> GetBranch(int projectId, int branchId);

        [Obsolete(MessageTexts.UseBranchesNamespace)]
        Task DeleteBranch(int projectId, int branchId);

        [Obsolete(MessageTexts.UseBranchesNamespace)]
        Task<Branch> EditBranch(int projectId, int branchId, IEnumerable<BranchPatch> patches);

        #endregion

        #region Directories

        Task<ResponseList<Directory>> ListDirectories(
            int projectId,
            int limit = 25,
            int offset = 0,
            int? branchId = null,
            int? directoryId = null,
            string? filter = null,
            object? recursion = null,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<Directory>> ListDirectories(int projectId, DirectoriesListParams @params);

        Task<Directory> AddDirectory(int projectId, AddDirectoryRequest request);

        Task<Directory> GetDirectory(int projectId, int directoryId);

        Task DeleteDirectory(int projectId, int directoryId);

        Task<Directory> EditDirectory(int projectId, int directoryId, IEnumerable<DirectoryPatch> patches);

        #endregion

        #region Files

        Task<ResponseList<T>> ListFiles<T>(int projectId,
            int limit = 25,
            int offset = 0,
            int? branchId = null,
            int? directoryId = null,
            string? filter = null,
            object? recursion = null,
            IEnumerable<SortingRule>? orderBy = null) where T : FileResourceBase;

        Task<ResponseList<T>> ListFiles<T>(int projectId, FilesListParams @params) where T : FileResourceBase;

        Task<File> AddFile(int projectId, AddFileRequest request);

        Task<TResponse> GetFile<TResponse>(int projectId, int fileId) where TResponse : FileInfoResource;

        Task<(File File, bool? IsModified)>
            UpdateOrRestoreFile(int projectId, int fileId, UpdateOrRestoreFileRequest request);

        Task DeleteFile(int projectId, int fileId);

        Task<File> EditFile(int projectId, int fileId, IEnumerable<FilePatch> patches);

        Task<DownloadLink> DownloadFile(int projectId, int fileId);

        Task<DownloadLink> DownloadFilePreview(int projectId, int fileId);

        Task<ResponseList<RevisionResource>> ListFileRevisions(int projectId, int fileId, int limit = 25, int offset = 0);

        Task<RevisionResource> GetFileRevision(int projectId, int fileId, int revisionId);

        #endregion

        #region Reviewed Source Files

        Task<ResponseList<ReviewedStringBuild>> ListReviewedSourceFilesBuilds(
            int projectId,
            int? branchId,
            int limit = 25,
            int offset = 0);

        Task<ReviewedStringBuild> BuildReviewedSourceFiles(int projectId, BuildReviewedSourceFilesRequest request);

        Task<ReviewedStringBuild> CheckReviewedSourceFilesBuildStatus(int projectId, int buildId);

        Task<DownloadLink> DownloadReviewedSourceFiles(int projectId, int buildId);

        #endregion
    }
}