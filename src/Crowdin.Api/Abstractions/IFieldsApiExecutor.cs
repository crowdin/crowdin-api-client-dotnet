
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Fields;

#nullable enable

namespace Crowdin.Api.Abstractions
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

        Task<Field> GetField(int fieldId);

        Task DeleteField(int fieldId);

        Task<Field> EditField(int fieldId, IEnumerable<FieldPatch> patches);
    }
}