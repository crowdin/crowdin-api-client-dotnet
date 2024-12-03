
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Screenshots;

#nullable enable

namespace Crowdin.Api.Abstractions
{
    [PublicAPI]
    public interface IScreenshotsApiExecutor
    {
        #region Screenshots

        Task<ResponseList<Screenshot>> ListScreenshots(
            int projectId,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null,
            IEnumerable<int>? stringIds = null);

        Task<Screenshot> AddScreenshot(int projectId, AddScreenshotRequest request);

        Task<Screenshot> GetScreenshot(int projectId, int screenshotId);

        Task<Screenshot> UpdateScreenshot(int projectId, int screenshotId, UpdateScreenshotRequest request);

        Task DeleteScreenshot(int projectId, int screenshotId);

        Task<Screenshot> EditScreenshot(int projectId, int screenshotId, IEnumerable<ScreenshotPatch> patches);

        #endregion

        #region Tags

        Task<ResponseList<Tag>> ListTags(int projectId, int screenshotId, int limit = 25, int offset = 0);

        Task ReplaceTags(int projectId, int screenshotId, IEnumerable<AddTagRequest> request);

        Task ReplaceTags(int projectId, int screenshotId, AutoTagReplaceTagsRequest request);

        Task<ResponseList<Tag>> AddTag(int projectId, int screenshotId, IEnumerable<AddTagRequest> request);

        Task ClearTags(int projectId, int screenshotId);

        Task<Tag> GetTag(int projectId, int screenshotId, int tagId);

        Task DeleteTag(int projectId, int screenshotId, int tagId);

        Task<Screenshot> EditTag(int projectId, int screenshotId, int tagId, IEnumerable<TagPatch> patches);

        #endregion
    }
}