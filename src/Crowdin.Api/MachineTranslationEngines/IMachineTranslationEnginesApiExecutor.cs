
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace Crowdin.Api.MachineTranslationEngines
{
    [PublicAPI]
    public interface IMachineTranslationEnginesApiExecutor
    {
        Task<ResponseList<MtEngine>> ListMts(long? groupId = null, int limit = 25, int offset = 0);

        Task<MtEngine> AddMt(AddMtEngineRequest request);

        Task<MtEngine> GetMt(long mtId);

        Task DeleteMt(long mtId);

        Task<MtEngine> EditMt(long mtId, IEnumerable<MtEnginePatch> patches);

        Task<MtTranslation> TranslateViaMt(long mtId, TranslateViaMtRequest request);
    }
}