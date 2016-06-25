using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CompassionFinal.Startup))]
namespace CompassionFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
