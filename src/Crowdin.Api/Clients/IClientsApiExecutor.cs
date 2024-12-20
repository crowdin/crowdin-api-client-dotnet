
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Crowdin.Api.Clients
{
    [PublicAPI]
    public interface IClientsApiExecutor
    {
        Task<ResponseList<Client>> ListClients(int limit = 25, int offset = 0);
    }
}