
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public interface IGlossariesApiExecutor
    {
        #region Glossaries

        Task<ResponseList<Glossary>> ListGlossaries(
            int limit = 25,
            int offset = 0,
            long? userId = null,
            long? groupId = null,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<Glossary>> ListGlossaries(GlossariesListParams @params);

        Task<Glossary> AddGlossary(AddGlossaryRequest request);

        Task<Glossary> GetGlossary(long glossaryId);

        Task DeleteGlossary(long glossaryId);

        Task<Glossary> EditGlossary(long glossaryId, IEnumerable<GlossaryPatch> patches);

        Task<ResponseList<GlossaryConcordanceResultResource>> ConcordanceSearch(
            long projectId,
            ConcordanceSearchRequest request);

        #endregion

        #region Glossaries : Export

        Task<GlossaryExportStatus> ExportGlossary(long glossaryId, ExportGlossaryRequest request);

        Task<GlossaryExportStatus> CheckGlossaryExportStatus(long glossaryId, string exportId);

        Task<DownloadLink> DownloadGlossary(long glossaryId, string exportId);

        #endregion

        #region Glossaries : Import

        Task<GlossaryImportStatus> ImportGlossary(long glossaryId, ImportGlossaryRequest request);

        Task<GlossaryImportStatus> CheckGlossaryImportStatus(long glossaryId, string importId);

        #endregion

        #region Terms

        Task<ResponseList<Term>> ListTerms(
            long glossaryId,
            long? userId = null,
            string? languageId = null,
            long? translationOfTermId = null,
            long? conceptId = null,
            string? croql = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<Term>> ListTerms(long glossaryId, TermsListParams @params);

        Task<Term> AddTerm(long glossaryId, AddTermRequest request);

        Task ClearGlossary(
            long glossaryId,
            string? languageId = null,
            long? conceptId = null,
            long? translationOfTermId = null);

        Task<Term> GetTerm(long glossaryId, long termId);

        Task DeleteTerm(long glossaryId, long termId);

        Task<Term> EditTerm(long glossaryId, long termId, IEnumerable<TermPatch> patches);

        #endregion

        #region Concepts

        Task<ResponseList<Concept>> ListConcepts(
            long glossaryId,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null);

        Task<Concept> GetConcept(long glossaryId, long conceptId);

        Task<Concept> UpdateConcept(long glossaryId, long conceptId, UpdateConceptRequest request);

        Task DeleteConcept(long glossaryId, long conceptId);

        #endregion
    }
}