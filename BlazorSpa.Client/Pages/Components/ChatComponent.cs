using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Extensions;
using BlazorSpa.Shared.Models;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorSpa.Client.Pages.Components
{
    public class ChatComponent : BlazorComponent
    {
        protected HubConnection connection;
        protected string message = "";
        protected List<Message> messages = new List<Message>();
        protected bool connected;
        protected string name = "";

        protected async Task Connect()
        {
            connection = new HubConnectionBuilder().WithUrl("/hub/chat").Build();
            connection.On<Message>("broadcastMessage", this.OnBroadcastMessage);
            await connection.StartAsync();

            connected = true;
        }

        protected async Task Disconnect()
        {
            await connection.StopAsync();
            name = "";
            connected = false;
        }

        protected Task OnBroadcastMessage(Message message)
        {
            messages.Add(message);
            StateHasChanged();
            return Task.CompletedTask;
        }

        protected async Task SendMessage()
        {
            await connection.InvokeAsync("Send", new Message { Sender = name, Text = message });
            message = "";
        }
    }
}
