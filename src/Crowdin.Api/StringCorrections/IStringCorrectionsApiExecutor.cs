using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crowdin.Api.StringCorrections
{
    public interface IStringCorrectionsApiExecutor
    {
        Task<ResponseList<Correction>> ListCorrections(
            int projectId,
            int stringId,
            IEnumerable<SortingRule>? orderBy = null,
            int denormalizePlaceholders = 0,
            int limit = 25,
            int offset = 0);

        Task<Correction> GetCorrection(int projectId, int correctionId);
        
        Task<Correction> AddCorrection(int projectId, AddCorrectionRequest request);
        
        Task DeleteCorrection(int projectId, int correctionId);
        
        Task DeleteCorrections(int projectId, int stringId);

        Task<Correction> RestoreCorrection(int projectId, int correctionId);
    }
}