using Gunz.Lobby.Common.CustomExceptions;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Gunz.Lobby.Common.Http
{
    public class AnonymousHttpClient : HttpClient, IAnonymousHttpClient
    {
        private static readonly JsonSerializerOptions DefaultOptions
            = new() { PropertyNameCaseInsensitive = true };

        public async Task<TResponse> PostAsync<TRequest, TResponse>(Uri requestUri, TRequest content)
        {
            var json = JsonSerializer.Serialize(content);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await PostAsync(requestUri, stringContent).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                throw new CustomHttpResponseException(response.StatusCode);

            var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
            return await JsonSerializer.DeserializeAsync<TResponse>(stream, DefaultOptions).ConfigureAwait(false);
        }
    }
}
