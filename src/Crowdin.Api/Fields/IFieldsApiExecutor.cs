
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.Fields
{
    [PublicAPI]
    public interface IFieldsApiExecutor
    {
        Task<ResponseList<Field>> ListFields(
            string? search,
            FieldEntity? entity,
            FieldType? type,
            int limit = 25,
            int offset = 0);

        Task<ResponseList<Field>> ListFields(FieldsListParams @params);

        Task<Field> AddField(AddFieldRequest request);

        Task<Field> GetField(long fieldId);

        Task DeleteField(long fieldId);

        Task<Field> EditField(long fieldId, IEnumerable<FieldPatch> patches);
    }
}