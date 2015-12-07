using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MetronicReady.Startup))]
namespace MetronicReady
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
