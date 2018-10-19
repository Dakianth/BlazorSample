using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using BlazorSpa.Shared.Models;
using Microsoft.AspNetCore.SignalR;

namespace BlazorSpa.Server.Hubs
{
    public class ChatHub : Hub
    {
        //public List<string> Connections { get; set; } = new List<string>();

        public Task Send(Message message)
        {
            return Clients.All.SendAsync("broadcastMessage", message);
        }

        //public override async Task OnConnectedAsync()
        //{
        //    Connections.Add(Context.ConnectionId);
        //    await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
        //    await base.OnConnectedAsync();
        //}

        //public override async Task OnDisconnectedAsync(Exception exception)
        //{
        //    Connections.Remove(Context.ConnectionId);
        //    await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
        //    await base.OnDisconnectedAsync(exception);
        //}
    }
}