
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Dictionaries;

namespace Crowdin.Api.Abstractions
{
    [PublicAPI]
    public interface IDictionariesApiExecutor
    {
        Task<ResponseList<Dictionary>> ListDictionaries(int projectId, string? languageIds = null);

        Task<Dictionary> EditDictionary(int projectId, string languageId, IEnumerable<DictionaryPatch> patches);
    }
}