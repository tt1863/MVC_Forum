using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Forum.Startup))]
namespace MVC_Forum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
