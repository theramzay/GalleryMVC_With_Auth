using System.Web.Mvc;

namespace GalleryMVC_With_Auth.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}