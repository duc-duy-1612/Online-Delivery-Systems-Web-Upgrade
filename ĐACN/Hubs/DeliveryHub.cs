using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using System.Diagnostics;

namespace ĐACN.Hubs
{
    public class DeliveryHub : Hub
    {
        // Khách hàng join group theo Mã Khách Hàng (ví dụ: KhachHang_KH001)
        // Nhà hàng join group theo Mã Nhà Hàng (ví dụ: NhaHang_NH001)
        // Shipper join group theo "Shippers" để nhận thông báo đơn mới, và "Shipper_SP001" cho tin cá nhân
        public Task JoinGroup(string groupName)
        {
            Debug.WriteLine($"SignalR: Connection {Context.ConnectionId} joined group {groupName}");
            return Groups.Add(Context.ConnectionId, groupName);
        }

        public Task LeaveGroup(string groupName)
        {
            Debug.WriteLine($"SignalR: Connection {Context.ConnectionId} left group {groupName}");
            return Groups.Remove(Context.ConnectionId, groupName);
        }
    }
}
