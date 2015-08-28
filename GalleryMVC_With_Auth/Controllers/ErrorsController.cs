using System.Web.Mvc;

namespace GalleryMVC_With_Auth.Controllers
{
    public class ErrorsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult BadRequest()
        {
            return View();
        }
    }
}