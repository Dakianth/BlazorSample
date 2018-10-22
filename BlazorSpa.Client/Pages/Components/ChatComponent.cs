using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Extensions;
using BlazorSpa.Client.Services;
using BlazorSpa.Shared.Models;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorSpa.Client.Pages.Components
{
    public class ChatComponent : BlazorComponent
    {
        [Inject]
        public ChatHub Hub { get; set; }
        protected string message = "";

        protected override void OnInit()
        {
            Hub.Messages.CollectionChanged -= OnMessageReceived;
            Hub.Messages.CollectionChanged += OnMessageReceived;
        }

        private void OnMessageReceived(object sender, NotifyCollectionChangedEventArgs e)
        {
            StateHasChanged();
        }

        protected async Task SendMessage()
        {
            await Hub.Connection.InvokeAsync("Send", new Message { Sender = Hub.Name, Text = message });
            message = "";
        }
    }
}
