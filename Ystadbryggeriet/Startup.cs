using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ystadbryggeriet.Startup))]
namespace Ystadbryggeriet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
