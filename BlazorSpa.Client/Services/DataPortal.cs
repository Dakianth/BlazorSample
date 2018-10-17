using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;

namespace BlazorSpa.Client.Services
{
    public class DataPortal
    {
        private readonly HttpClient httpClient;
        private readonly TokenService tokenService;

        public DataPortal(HttpClient httpClient, TokenService tokenService)
        {
            this.httpClient = httpClient;
            this.tokenService = tokenService;
        }

        private async Task SetToken()
        {
            var token = await tokenService.GetAccessToken();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token} ");
        }

        public async Task<T> GetJsonAsync<T>(string requestUri)
        {
            await SetToken();
            return await httpClient.GetJsonAsync<T>(requestUri);
        }

        public async Task PostJsonAsync(string requestUri, object content)
        {
            await SetToken();
            await httpClient.PostJsonAsync(requestUri, content);
        }

        public async Task<T> PostJsonAsync<T>(string requestUri, object content)
        {
            await SetToken();
            return await httpClient.PostJsonAsync<T>(requestUri, content);
        }

        public async Task PutJsonAsync(string requestUri, object content)
        {
            await SetToken();
            await httpClient.PutJsonAsync(requestUri, content);
        }

        public async Task<T> PutJsonAsync<T>(string requestUri, object content)
        {
            await SetToken();
            return await httpClient.PutJsonAsync<T>(requestUri, content);
        }

        public async Task SendJsonAsync(HttpMethod method, string requestUri, object content)
        {
            await SetToken();
            await httpClient.SendJsonAsync(method, requestUri, content);
        }

        public async Task<T> SendJsonAsync<T>(HttpMethod method, string requestUri, object content)
        {
            await SetToken();
            return await httpClient.SendJsonAsync<T>(method, requestUri, content);
        }
    }
}
