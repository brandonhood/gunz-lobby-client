using Gunz.Lobby.Common.Http;
using Gunz.Lobby.Domain.Contracts.Security;
using System;
using System.Threading.Tasks;

namespace Gunz.Lobby.Repositories.Security
{
    public class ApiTokenRepository : IApiTokenRepository
    {
        private readonly IAnonymousHttpClient _anonymousHttpClient;

        public ApiTokenRepository(IAnonymousHttpClient anonymousHttpClient)
        {
            _anonymousHttpClient = anonymousHttpClient;
        }

        public async Task<ApiTokenResponse> GetApiTokenAsync(string serverUri, string username, string password)
        {
            var request = new ApiTokenRequest()
            {
                Username = username,
                Password = password
            };

            var uri = new Uri(new Uri(serverUri), "api/apitoken");

            return await _anonymousHttpClient.PostAsync<ApiTokenRequest, ApiTokenResponse>(uri, request);
        }
    }
}
