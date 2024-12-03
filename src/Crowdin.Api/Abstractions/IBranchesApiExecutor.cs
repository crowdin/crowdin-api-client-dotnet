
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Branches;

#nullable enable

namespace Crowdin.Api.Abstractions
{
    [PublicAPI]
    public interface IBranchesApiExecutor
    {
        Task<Branch> GetClonedBranch(int projectId, int branchId, string cloneId);

        Task<BranchCloneStatus> CloneBranch(int projectId, int branchId, CloneBranchRequest request);

        Task<BranchCloneStatus> CheckBranchCloneStatus(int projectId, int branchId, string cloneId);

        Task<ResponseList<Branch>> ListBranches(
            int projectId,
            string? name = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null);

        Task<Branch> AddBranch(int projectId, AddBranchRequest request);

        Task<Branch> GetBranch(int projectId, int branchId);

        Task DeleteBranch(int projectId, int branchId);

        Task<Branch> EditBranch(int projectId, int branchId, IEnumerable<BranchPatch> patches);

        Task<BranchMergeStatus> MergeBranch(int projectId, int branchId, MergeBranchRequest request);

        Task<BranchMergeStatus> CheckBranchMergeStatus(int projectId, int branchId, string mergeId);

        Task<BranchMergeSummary> GetBranchMergeSummary(int projectId, int branchId, string mergeId);
    }
}