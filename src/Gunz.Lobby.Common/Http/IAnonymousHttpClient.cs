using System;
using System.Threading.Tasks;

namespace Gunz.Lobby.Common.Http
{
    public interface IAnonymousHttpClient
    {
        Task<TResponse> PostAsync<TRequest, TResponse>(Uri requestUri, TRequest content);
    }
}
