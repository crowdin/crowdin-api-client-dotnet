
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.MachineTranslationEngines;

namespace Crowdin.Api.Abstractions
{
    [PublicAPI]
    public interface IMachineTranslationEnginesApiExecutor
    {
        Task<ResponseList<MtEngine>> ListMts(int? groupId = null, int limit = 25, int offset = 0);

        Task<MtEngine> AddMt(AddMtEngineRequest request);

        Task<MtEngine> GetMt(int mtId);

        Task DeleteMt(int mtId);

        Task<MtEngine> EditMt(int mtId, IEnumerable<MtEnginePatch> patches);

        Task<MtTranslation> TranslateViaMt(int mtId, TranslateViaMtRequest request);
    }
}