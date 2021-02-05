using Gunz.Lobby.Domain.Contracts.Security;
using System.Threading.Tasks;

namespace Gunz.Lobby.Repositories.Security
{
    public interface IApiTokenRepository
    {
        Task<ApiTokenResponse> GetApiTokenAsync(string serverUri, string username, string password);
    }
}
