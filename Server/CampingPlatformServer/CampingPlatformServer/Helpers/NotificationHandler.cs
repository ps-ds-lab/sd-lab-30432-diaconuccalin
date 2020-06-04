using System.Threading.Tasks;
using WebSocketManager;

namespace CampingPlatformServer.Helpers
{
    public class NotificationHandler : WebSocketHandler
    {
        public NotificationHandler(WebSocketConnectionManager webSocketConnetcionManager) : base(webSocketConnetcionManager)
        {

        }

        public async Task SendNotification(string socketId, string message)
        {
            await InvokeClientMethodToAllAsync("pingMessage", socketId, message);
        }
    }
}
