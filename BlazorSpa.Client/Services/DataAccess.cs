using System.Net.Http;
using System.Threading.Tasks;
using BlazorSpa.Shared;
using Microsoft.AspNetCore.Blazor;

namespace BlazorSpa.Client.Services
{
    public class DataAccess : IDataAccess
    {
        private readonly HttpClient httpClient;

        public DataAccess(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        private async Task SetToken()
        {
            var token = await JSHelper.GetAccessToken();
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
