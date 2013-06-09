using Microsoft.AspNet.SignalR;

namespace Reader.Infrastructure
{
    public class NotificationHub : Hub
    {
        public void Notify(string message) {
            Clients.All.Message(message);
        }
    }
}