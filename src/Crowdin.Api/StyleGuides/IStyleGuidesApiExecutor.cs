
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Crowdin.Api.StyleGuides
{
    [PublicAPI]
    public interface IStyleGuidesApiExecutor
    {
        Task<ResponseList<StyleGuide>> ListStyleGuides(int limit = 25, int offset = 0);

        Task<StyleGuide> AddStyleGuide(AddStyleGuideRequest request);

        Task<StyleGuide> GetStyleGuide(long styleGuideId);

        Task<StyleGuide> EditStyleGuide(long styleGuideId, IEnumerable<StyleGuidePatch> patches);

        Task DeleteStyleGuide(long styleGuideId);
    }
}
