using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorSpa.Shared;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;

namespace BlazorSpa.Client.Pages.Components
{
    public class RegistrationComponent : BlazorComponent
    {
        [Inject]
        protected IUriHelper UriHelper { get; set; }

        [Inject]
        protected HttpClient Http { get; set; }

        public string Email { get; set; } = "";
        public string Password { get; set; } = "";

        protected async Task SubmitFrom()
        {
            var vm = new TokenViewModel
            {
                Email = Email,
                Password = Password
            };

            var response = await Http.PostJsonAsync<object>("api/Token/Registration", vm);

            UriHelper.NavigateTo("/login");
        }
    }
}
