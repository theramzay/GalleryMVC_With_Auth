using System.Web.Mvc;
using System.Web.Routing;
using GalleryMVC_With_Auth.Resources;

namespace GalleryMVC_With_Auth
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = Defines.HomeControllerName, action = Defines.IndexView, id = UrlParameter.Optional}
                );
        }
    }
}