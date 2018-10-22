using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Blazor.Extensions;
using BlazorSpa.Shared.Models;

namespace BlazorSpa.Client.Services
{
    public class ChatHub : INotifyPropertyChanged
    {
        private readonly AuthStore authStore;

        public HubConnection Connection { get; set; }

        public ObservableCollection<Message> Messages { get; private set; } = new ObservableCollection<Message>();

        public bool Connected { get; private set; }

        private int unreadMessages = 0;
        public int UnreadMessages
        {
            get => unreadMessages;
            private set
            {
                unreadMessages = value;
                NotifyPropertyChanged();
            }
        }

        public string Name => authStore.CurrentUser?.Name ?? "Slender";

        public event PropertyChangedEventHandler PropertyChanged;

        public ChatHub(AuthStore authStore)
        {
            this.authStore = authStore;

            Messages.CollectionChanged -= OnReceiveMessage;
            Messages.CollectionChanged += OnReceiveMessage;
        }

        private void OnReceiveMessage(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UnreadMessages = Messages.Count(c => c.Unreaded);
            Console.WriteLine($"Unread messages: {UnreadMessages}");
            //TODO: Add toaster
        }

        public async Task Connect()
        {
            Connection = new HubConnectionBuilder()
                .WithUrl("/hub/chat", options => { options.AccessTokenProvider = GetJwtToken; })
                .Build();

            Connection.On<Message>("broadcastMessage", OnBroadcastMessage);

            await Connection.StartAsync();
            Connected = true;

            async Task<string> GetJwtToken()
            {
                await Task.Delay(0);
                return authStore.Token;
            }
        }

        public async Task Disconnect()
        {
            await Connection.StopAsync();
            Connected = false;
        }

        protected Task OnBroadcastMessage(Message message)
        {
            message.Unreaded = true;
            Messages.Add(message);
            return Task.CompletedTask;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}