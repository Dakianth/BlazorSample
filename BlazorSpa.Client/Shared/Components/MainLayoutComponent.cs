using System.Collections.Specialized;
using System.Threading.Tasks;
using BlazorSpa.Client.Services;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Layouts;
using Microsoft.AspNetCore.Blazor.Services;

namespace BlazorSpa.Client.Shared.Components
{
    public class MainLayoutComponent : BlazorLayoutComponent
    {
        [Inject]
        protected IUriHelper UriHelper { get; set; }

        [Inject]
        protected AuthStore AuthStore { get; set; }

        [Inject]
        protected ChatHub Hub { get; set; }

        private int counter = 0;
        private readonly ThemeInfo theme = new ThemeInfo { ButtonClass = "btn-success" };

        protected override void OnInit()
        {
            Hub.Messages.CollectionChanged -= OnMessageReceived;
            Hub.Messages.CollectionChanged += OnMessageReceived;
        }

        protected override async Task OnInitAsync()
        {
            if (!await AuthStore.GetAccessToken())
            {
                UriHelper.NavigateTo("/login");
                return;
            }
        }

        private void OnMessageReceived(object sender, NotifyCollectionChangedEventArgs e)
        {
            StateHasChanged();
        }

        private void Increment()
        {
            counter++;
        }
    }
}
