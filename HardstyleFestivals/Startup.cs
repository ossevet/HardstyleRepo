using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HardstyleFestivals.Startup))]
namespace HardstyleFestivals
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
