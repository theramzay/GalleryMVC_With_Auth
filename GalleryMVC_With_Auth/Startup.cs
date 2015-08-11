using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GalleryMVC_With_Auth.Startup))]
namespace GalleryMVC_With_Auth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
