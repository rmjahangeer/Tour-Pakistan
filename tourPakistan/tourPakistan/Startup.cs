using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(tourPakistan.Startup))]
namespace tourPakistan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
