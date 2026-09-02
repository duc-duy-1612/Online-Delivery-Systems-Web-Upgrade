using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using ĐACN.Models;

namespace ĐACN.Hubs
{
    public class ChatHub : Hub
    {
        // Lưu trữ ConnectionId theo UserId để gửi tin nhắn riêng (Private Message)
        // Trong thực tế nên lưu vào Database hoặc Redis, ở đây dùng bộ nhớ tạm
        private static readonly ConcurrentDictionary<string, string> UserConnections = new ConcurrentDictionary<string, string>();

        public void Connect(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                UserConnections[userId] = Context.ConnectionId;
            }
        }

        public async Task JoinOrderGroup(string maDon)
        {
            if (!string.IsNullOrEmpty(maDon))
            {
                await Groups.Add(Context.ConnectionId, "Order_" + maDon);
            }
        }

        public async Task SendMessage(string senderId, string senderName, string receiverId, string message, string maDon)
        {
            if (string.IsNullOrEmpty(message)) return;

            var msgObj = new {
                id = Guid.NewGuid().ToString(),
                senderId = senderId,
                senderName = senderName,
                receiverId = receiverId,
                message = message,
                timestamp = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds
            };

            // Nếu có mã đơn, gửi cho tất cả người trong nhóm đơn hàng đó
            if (!string.IsNullOrEmpty(maDon))
            {
                await Clients.Group("Order_" + maDon).receiveMessage(msgObj);
            }
            else
            {
                // Gửi trực tiếp cho người nhận nếu họ đang online
                if (!string.IsNullOrEmpty(receiverId) && UserConnections.TryGetValue(receiverId, out string receiverConnectionId))
                {
                    await Clients.Client(receiverConnectionId).receiveMessage(msgObj);
                }
                
                // Gửi lại cho chính người gửi để hiển thị
                await Clients.Caller.receiveMessage(msgObj);
            }
        }
    }
}
