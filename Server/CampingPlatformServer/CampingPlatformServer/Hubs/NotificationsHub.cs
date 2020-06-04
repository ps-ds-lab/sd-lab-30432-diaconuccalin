using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CampingPlatformServer.Hubs
{
    public class NotificationsHub : Hub
    {
        public async Task SendNotification(string message)
        {
            await Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}
