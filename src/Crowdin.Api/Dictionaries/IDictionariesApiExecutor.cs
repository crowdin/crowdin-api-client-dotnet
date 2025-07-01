
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.Dictionaries
{
    [PublicAPI]
    public interface IDictionariesApiExecutor
    {
        Task<ResponseList<Dictionary>> ListDictionaries(long projectId, string? languageIds = null);

        Task<Dictionary> EditDictionary(long projectId, string languageId, IEnumerable<DictionaryPatch> patches);
    }
}