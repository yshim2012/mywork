using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(tongqinche.Startup))]
namespace tongqinche
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
