using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Art_shop_Website.Startup))]
namespace Art_shop_Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
