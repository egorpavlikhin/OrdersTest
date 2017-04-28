using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OrdersTest.Startup))]
namespace OrdersTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
