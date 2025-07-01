
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.Branches
{
    [PublicAPI]
    public interface IBranchesApiExecutor
    {
        Task<Branch> GetClonedBranch(long projectId, long branchId, string cloneId);

        Task<BranchCloneStatus> CloneBranch(long projectId, long branchId, CloneBranchRequest request);

        Task<BranchCloneStatus> CheckBranchCloneStatus(long projectId, long branchId, string cloneId);

        Task<ResponseList<Branch>> ListBranches(
            long projectId,
            string? name = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null);

        Task<Branch> AddBranch(long projectId, AddBranchRequest request);

        Task<Branch> GetBranch(long projectId, long branchId);

        Task DeleteBranch(long projectId, long branchId);

        Task<Branch> EditBranch(long projectId, long branchId, IEnumerable<BranchPatch> patches);

        Task<BranchMergeStatus> MergeBranch(long projectId, long branchId, MergeBranchRequest request);

        Task<BranchMergeStatus> CheckBranchMergeStatus(long projectId, long branchId, string mergeId);

        Task<BranchMergeSummary> GetBranchMergeSummary(long projectId, long branchId, string mergeId);
    }
}