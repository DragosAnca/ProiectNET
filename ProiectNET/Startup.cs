using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProiectNET.Startup))]
namespace ProiectNET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
