using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BlazorSpa.Shared.Models;
using Microsoft.AspNetCore.Blazor;
using Microsoft.JSInterop;

namespace BlazorSpa.Client.Services
{
    public class AuthStore
    {
        private readonly HttpClient httpClient;

        public bool IsAuth { get; private set; }
        public User CurrentUser { get; private set; }
        public string Token { get; private set; }

        public AuthStore(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task Login(string token)
        {
            Token = token;

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var user = await httpClient.GetJsonAsync<User>("api/Token/Info");

            await JSHelper.SaveAccessToken(token);

            CurrentUser = user;
            IsAuth = true;
        }

        public async Task Logout()
        {
            CurrentUser = null;
            IsAuth = false;

            await JSHelper.SaveAccessToken(null);
        }

        public async Task<bool> GetAccessToken()
        {
            //Get token from localStorage
            var token = await JSHelper.GetAccessToken();

            //Check token validity
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var responseMessage = await httpClient.GetAsync("api/Token/Info");
            Console.WriteLine(responseMessage.StatusCode);
            //Ensure Success Status Code
            if (!responseMessage.IsSuccessStatusCode)
                return false;

            //Load user info
            var user = Json.Deserialize<User>(await responseMessage.Content.ReadAsStringAsync());
            CurrentUser = user;

            Token = token;
            IsAuth = !string.IsNullOrWhiteSpace(Token);
            return IsAuth;
        }
    }
}