#nullable enable

using System.Collections.Generic;
using System.Threading.Tasks;
using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.Placeholders
{
    [PublicAPI]
    public interface IPlaceholdersApiExecutor
    {
        Task<ResponseList<SystemPlaceholder>> ListSystemPlaceholders(
            long projectId,
            int limit = 25,
            int offset = 0);

        Task<SystemPlaceholder[]> SystemPlaceholdersBatchOperations(
            long projectId,
            IEnumerable<SystemPlaceholdersBatchPatch> patches);

        Task<ResponseList<CustomPlaceholder>> ListCustomPlaceholders(int limit = 25, int offset = 0);

        Task<CustomPlaceholder> AddCustomPlaceholder(AddCustomPlaceholderRequest request);

        Task<CustomPlaceholder> GetCustomPlaceholder(long customPlaceholderId);

        Task<CustomPlaceholder> EditCustomPlaceholder(
            long customPlaceholderId,
            IEnumerable<CustomPlaceholderPatch> patches);

        Task DeleteCustomPlaceholder(long customPlaceholderId);

        Task<ResponseList<ProjectPlaceholder>> ListProjectPlaceholders(
            long projectId,
            int limit = 25,
            int offset = 0);

        Task<ProjectPlaceholder> AddProjectPlaceholder(long projectId, AddProjectPlaceholderRequest request);

        Task<ProjectPlaceholder> GetProjectPlaceholder(long projectId, long projectPlaceholderId);

        Task<ProjectPlaceholder> EditProjectPlaceholder(
            long projectId,
            long projectPlaceholderId,
            IEnumerable<ProjectPlaceholderPatch> patches);

        Task DeleteProjectPlaceholder(long projectId, long projectPlaceholderId);
    }
}
