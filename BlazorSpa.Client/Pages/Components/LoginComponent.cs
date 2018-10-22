using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BlazorSpa.Client.Services;
using BlazorSpa.Shared;
using BlazorSpa.Shared.Models;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;

namespace BlazorSpa.Client.Pages.Components
{
    public class LoginComponent : BlazorComponent
    {
        [Inject]
        protected IUriHelper UriHelper { get; set; }

        [Inject]
        protected HttpClient Http { get; set; }

        [Inject]
        protected AuthStore AuthStore { get; set; }

        [Inject]
        protected ChatHub Hub { get; set; }

        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string Token { get; set; } = "";

        protected async Task SubmitFrom()
        {
            var vm = new TokenViewModel
            {
                Email = Email,
                Password = Password
            };

            var response = await Http.PostJsonAsync<TokenResponse>("api/Token/Login", vm);

            //Http.DefaultRequestHeaders.Add("Authorization", $"Bearer {response.Token} ");
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", response.Token);
            var user = await Http.GetJsonAsync<User>("api/Token/Info");

            await AuthStore.Login(user, response.Token);

            await Hub.Connect();
            UriHelper.NavigateTo("/");
        }
    }
}
