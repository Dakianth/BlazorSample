using System.Threading.Tasks;
using BlazorSpa.Client.Services;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;

namespace BlazorSpa.Client.Pages.Components
{
    public class LogoutComponent : BlazorComponent
    {
        [Inject]
        protected IUriHelper UriHelper { get; set; }

        [Inject]
        protected AuthStore AuthStore { get; set; }

        protected override async Task OnInitAsync()
        {
            await AuthStore.Logout();
            UriHelper.NavigateTo("/login");
        }
    }
}