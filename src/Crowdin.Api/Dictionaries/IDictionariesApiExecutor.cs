
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace Crowdin.Api.Dictionaries
{
    [PublicAPI]
    public interface IDictionariesApiExecutor
    {
        Task<ResponseList<Dictionary>> ListDictionaries(int projectId, string? languageIds = null);

        Task<Dictionary> EditDictionary(int projectId, string languageId, IEnumerable<DictionaryPatch> patches);
    }
}