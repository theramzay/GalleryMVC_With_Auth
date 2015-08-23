using System.Web.Mvc;
using System.Web.Routing;

namespace GalleryMVC_With_Auth
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = "StartHome", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}