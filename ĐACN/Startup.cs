using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ĐACN.Startup))]

namespace ĐACN
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Cấu hình SignalR để chạy trên route mặc định /signalr
            app.MapSignalR();
        }
    }
}
