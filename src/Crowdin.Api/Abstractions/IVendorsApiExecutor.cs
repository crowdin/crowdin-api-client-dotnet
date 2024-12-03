
using System.Threading.Tasks;
using JetBrains.Annotations;
using Crowdin.Api.Vendors;

namespace Crowdin.Api.Abstractions
{
    [PublicAPI]
    public interface IVendorsApiExecutor
    {
        Task<ResponseList<Vendor>> ListVendors(int limit = 25, int offset = 0);
    }
}