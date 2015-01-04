using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITBedrijf.Startup))]
namespace ITBedrijf
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
