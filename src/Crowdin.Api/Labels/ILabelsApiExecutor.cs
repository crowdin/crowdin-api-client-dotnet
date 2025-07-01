
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Screenshots;
using Crowdin.Api.SourceStrings;

#nullable enable

namespace Crowdin.Api.Labels
{
    [PublicAPI]
    public interface ILabelsApiExecutor
    {
        Task<ResponseList<Label>> ListLabels(
            long projectId,
            int limit = 25,
            int offset = 0,
            bool? isSystem = null,
            IEnumerable<SortingRule>? orderBy = null);

        Task<Label> AddLabel(long projectId, string title);

        Task<Label> AddLabel(long projectId, AddLabelRequest request);

        Task<Label> GetLabel(long projectId, long labelId);

        Task DeleteLabel(long projectId, long labelId);

        Task<Label> EditLabel(long projectId, long labelId, IEnumerable<LabelPatch> patches);

        Task<ResponseList<SourceString>> AssignLabelToStrings(
            long projectId,
            long labelId,
            ICollection<long> stringIds);

        Task<ResponseList<SourceString>> AssignLabelToStrings(
            long projectId,
            long labelId,
            AssignLabelToStringsRequest request);

        Task<ResponseList<SourceString>> UnassignLabelFromStrings(
            long projectId,
            long labelId,
            ICollection<long> stringIds);

        Task<ResponseList<Screenshot>> AssignLabelToScreenshots(
            long projectId,
            long labelId,
            AssignLabelToScreenshotsRequest request);

        Task<ResponseList<Screenshot>> UnassignLabelFromScreenshots(
            long projectId,
            long labelId,
            IEnumerable<long> screenshotIds);
    }
}