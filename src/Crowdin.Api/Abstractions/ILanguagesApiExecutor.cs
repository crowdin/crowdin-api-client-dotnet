
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Languages;

namespace Crowdin.Api.Abstractions
{
    [PublicAPI]
    public interface ILanguagesApiExecutor
    {
        Task<ResponseList<Language>> ListSupportedLanguages(int limit = 25, int offset = 0);

        Task<Language> AddCustomLanguage(AddCustomLanguageRequest request);

        Task<Language> GetLanguage(string languageId);

        Task DeleteCustomLanguage(string languageId);

        Task<Language> EditCustomLanguage(string languageId, IEnumerable<LanguagePatch> patches);
    }
}