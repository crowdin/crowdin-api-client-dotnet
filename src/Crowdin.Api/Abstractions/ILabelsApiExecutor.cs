
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Labels;
using Crowdin.Api.Screenshots;
using Crowdin.Api.SourceStrings;

#nullable enable

namespace Crowdin.Api.Abstractions
{
    [PublicAPI]
    public interface ILabelsApiExecutor
    {
        Task<ResponseList<Label>> ListLabels(
            int projectId,
            int limit = 25,
            int offset = 0,
            bool? isSystem = null,
            IEnumerable<SortingRule>? orderBy = null);

        Task<Label> AddLabel(int projectId, string title);

        Task<Label> AddLabel(int projectId, AddLabelRequest request);

        Task<Label> GetLabel(int projectId, int labelId);

        Task DeleteLabel(int projectId, int labelId);

        Task<Label> EditLabel(int projectId, int labelId, IEnumerable<LabelPatch> patches);

        Task<ResponseList<SourceString>> AssignLabelToStrings(
            int projectId,
            int labelId,
            ICollection<int> stringIds);

        Task<ResponseList<SourceString>> AssignLabelToStrings(
            int projectId,
            int labelId,
            AssignLabelToStringsRequest request);

        Task<ResponseList<SourceString>> UnassignLabelFromStrings(
            int projectId,
            int labelId,
            ICollection<int> stringIds);

        Task<ResponseList<Screenshot>> AssignLabelToScreenshots(
            int projectId,
            int labelId,
            AssignLabelToScreenshotsRequest request);

        Task<ResponseList<Screenshot>> UnassignLabelFromScreenshots(
            int projectId,
            int labelId,
            IEnumerable<int> screenshotIds);
    }
}