using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlayerTracker.Startup))]
namespace PlayerTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
