
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
            int? userId = null,
            int? groupId = null,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<Glossary>> ListGlossaries(GlossariesListParams @params);

        Task<Glossary> AddGlossary(AddGlossaryRequest request);

        Task<Glossary> GetGlossary(int glossaryId);

        Task DeleteGlossary(int glossaryId);

        Task<Glossary> EditGlossary(int glossaryId, IEnumerable<GlossaryPatch> patches);

        Task<ResponseList<GlossaryConcordanceResultResource>> ConcordanceSearch(
            int projectId,
            ConcordanceSearchRequest request);

        #endregion

        #region Glossaries : Export

        Task<GlossaryExportStatus> ExportGlossary(int glossaryId, ExportGlossaryRequest request);

        Task<GlossaryExportStatus> CheckGlossaryExportStatus(int glossaryId, string exportId);

        Task<DownloadLink> DownloadGlossary(int glossaryId, string exportId);

        #endregion

        #region Glossaries : Import

        Task<GlossaryImportStatus> ImportGlossary(int glossaryId, ImportGlossaryRequest request);

        Task<GlossaryImportStatus> CheckGlossaryImportStatus(int glossaryId, string importId);

        #endregion

        #region Terms

        Task<ResponseList<Term>> ListTerms(
            int glossaryId,
            int? userId = null,
            string? languageId = null,
            int? translationOfTermId = null,
            int? conceptId = null,
            string? croql = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<Term>> ListTerms(int glossaryId, TermsListParams @params);

        Task<Term> AddTerm(int glossaryId, AddTermRequest request);

        Task ClearGlossary(
            int glossaryId,
            string? languageId = null,
            int? conceptId = null,
            int? translationOfTermId = null);

        Task<Term> GetTerm(int glossaryId, int termId);

        Task DeleteTerm(int glossaryId, int termId);

        Task<Term> EditTerm(int glossaryId, int termId, IEnumerable<TermPatch> patches);

        #endregion

        #region Concepts

        Task<ResponseList<Concept>> ListConcepts(
            int glossaryId,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null);

        Task<Concept> GetConcept(int glossaryId, int conceptId);

        Task<Concept> UpdateConcept(int glossaryId, int conceptId, UpdateConceptRequest request);

        Task DeleteConcept(int glossaryId, int conceptId);

        #endregion
    }
}