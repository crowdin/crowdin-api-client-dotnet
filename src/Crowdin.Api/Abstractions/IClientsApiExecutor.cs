
using System.Threading.Tasks;
using JetBrains.Annotations;
using Crowdin.Api.Clients;

namespace Crowdin.Api.Abstractions
{
    [PublicAPI]
    public interface IClientsApiExecutor
    {
        Task<ResponseList<Client>> ListClients(int limit = 25, int offset = 0);
    }
}