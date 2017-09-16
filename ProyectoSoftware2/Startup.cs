using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoSoftware2.Startup))]
namespace ProyectoSoftware2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
