
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.Screenshots
{
    [PublicAPI]
    public interface IScreenshotsApiExecutor
    {
        #region Screenshots

        Task<ResponseList<Screenshot>> ListScreenshots(
            long projectId,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null,
            IEnumerable<long>? stringIds = null);

        Task<Screenshot> AddScreenshot(long projectId, AddScreenshotRequest request);

        Task<Screenshot> GetScreenshot(long projectId, long screenshotId);

        Task<Screenshot> UpdateScreenshot(long projectId, long screenshotId, UpdateScreenshotRequest request);

        Task DeleteScreenshot(long projectId, long screenshotId);

        Task<Screenshot> EditScreenshot(long projectId, long screenshotId, IEnumerable<ScreenshotPatch> patches);

        #endregion

        #region Tags

        Task<ResponseList<Tag>> ListTags(long projectId, long screenshotId, int limit = 25, int offset = 0);

        Task ReplaceTags(long projectId, long screenshotId, IEnumerable<AddTagRequest> request);

        Task ReplaceTags(long projectId, long screenshotId, AutoTagReplaceTagsRequest request);

        Task<ResponseList<Tag>> AddTag(long projectId, long screenshotId, IEnumerable<AddTagRequest> request);

        Task ClearTags(long projectId, long screenshotId);

        Task<Tag> GetTag(long projectId, long screenshotId, long tagId);

        Task DeleteTag(long projectId, long screenshotId, long tagId);

        Task<Screenshot> EditTag(long projectId, long screenshotId, long tagId, IEnumerable<TagPatch> patches);

        #endregion
    }
}