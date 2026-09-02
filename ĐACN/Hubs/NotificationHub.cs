using System.Collections.Concurrent;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace ĐACN.Hubs
{
    public class NotificationHub : Hub
    {
        // Quản lý kết nối để có thể gửi thông báo cho 1 user cụ thể (Khách hàng hoặc Nhà hàng)
        private static readonly ConcurrentDictionary<string, string> UserConnections = new ConcurrentDictionary<string, string>();

        public void Connect(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                UserConnections[userId] = Context.ConnectionId;
            }
        }

        // Cập nhật thông báo đơn hàng cho một user cụ thể
        public static void NotifyOrderUpdate(string receiverId, string title, string message, string type = "info")
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            
            if (!string.IsNullOrEmpty(receiverId) && UserConnections.TryGetValue(receiverId, out string connectionId))
            {
                hubContext.Clients.Client(connectionId).receiveNotification(title, message, type);
            }
        }
        
        // Gửi thông báo đến toàn bộ các user (ví dụ: Hệ thống bảo trì)
        public static void NotifyAll(string title, string message, string type = "info")
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            hubContext.Clients.All.receiveNotification(title, message, type);
        }
    }
}
