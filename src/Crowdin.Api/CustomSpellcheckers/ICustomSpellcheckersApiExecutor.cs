#nullable enable

using System.Threading.Tasks;

using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.CustomSpellcheckers
{
    [PublicAPI]
    public interface ICustomSpellcheckersApiExecutor
    {
        Task<ResponseList<CustomSpellchecker>> ListCustomSpellcheckers(int limit = 25, int offset = 0);

        Task<CustomSpellchecker> GetCustomSpellchecker(long customSpellcheckerId);
    }
}
