using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BlazorSpa.Shared;
using Microsoft.AspNetCore.Blazor;

namespace BlazorSpa.Client.Services
{
    public class DataAccess : IDataAccess
    {
        private readonly HttpClient httpClient;
        private readonly AuthStore authStore;

        public DataAccess(HttpClient httpClient, AuthStore authStore)
        {
            this.httpClient = httpClient;
            this.authStore = authStore;
        }

        private void SetToken()
        {
            //httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {authStore.Token} ");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authStore.Token);
        }

        public async Task<T> GetJsonAsync<T>(string requestUri)
        {
            SetToken();
            return await httpClient.GetJsonAsync<T>(requestUri);
        }

        public async Task PostJsonAsync(string requestUri, object content)
        {
            SetToken();
            await httpClient.PostJsonAsync(requestUri, content);
        }

        public async Task<T> PostJsonAsync<T>(string requestUri, object content)
        {
            SetToken();
            return await httpClient.PostJsonAsync<T>(requestUri, content);
        }

        public async Task PutJsonAsync(string requestUri, object content)
        {
            SetToken();
            await httpClient.PutJsonAsync(requestUri, content);
        }

        public async Task<T> PutJsonAsync<T>(string requestUri, object content)
        {
            SetToken();
            return await httpClient.PutJsonAsync<T>(requestUri, content);
        }

        public async Task SendJsonAsync(HttpMethod method, string requestUri, object content)
        {
            SetToken();
            await httpClient.SendJsonAsync(method, requestUri, content);
        }

        public async Task<T> SendJsonAsync<T>(HttpMethod method, string requestUri, object content)
        {
            SetToken();
            return await httpClient.SendJsonAsync<T>(method, requestUri, content);
        }
    }
}
