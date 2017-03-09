using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Biblioteca_eCommerce.Startup))]
namespace Biblioteca_eCommerce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
