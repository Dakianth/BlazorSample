using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorSpa.Client.Services;
using BlazorSpa.Shared;
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
            await JSHelper.SaveAccessToken(response.Token);

            AuthStore.IsAuth = true;
            UriHelper.NavigateTo("/");
        }
    }
}
