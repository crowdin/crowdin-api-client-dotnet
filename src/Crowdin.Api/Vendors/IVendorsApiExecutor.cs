
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Crowdin.Api.Vendors
{
    [PublicAPI]
    public interface IVendorsApiExecutor
    {
        Task<ResponseList<Vendor>> ListVendors(int limit = 25, int offset = 0);
    }
}