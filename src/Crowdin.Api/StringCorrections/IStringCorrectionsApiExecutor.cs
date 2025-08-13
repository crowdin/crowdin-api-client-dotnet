using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crowdin.Api.StringCorrections
{
    public interface IStringCorrectionsApiExecutor
    {
        Task<ResponseList<Correction>> ListCorrections(
            long projectId,
            long stringId,
            IEnumerable<SortingRule>? orderBy = null,
            int denormalizePlaceholders = 0,
            int limit = 25,
            int offset = 0);

        Task<Correction> GetCorrection(long projectId, long correctionId);
        
        Task<Correction> AddCorrection(long projectId, AddCorrectionRequest request);
        
        Task DeleteCorrection(long projectId, long correctionId);
        
        Task DeleteCorrections(long projectId, long stringId);

        Task<Correction> RestoreCorrection(long projectId, long correctionId);
    }
}