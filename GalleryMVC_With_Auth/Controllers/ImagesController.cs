using System.Web.Mvc;
using GalleryMVC_With_Auth.Domain.Abstract;
using GalleryMVC_With_Auth.Domain.Entities;

namespace GalleryMVC_With_Auth.Controllers
{
    public class ImagesController : Controller
    {
        // GET: Images
        public ActionResult Jivopis()
        {
            return View();
        }

        public ActionResult Akvarel()
        {
            return View();
        }

        public ActionResult Guash()
        {
            return View();
        }

        public ActionResult Grafica()
        {
            return View();
        }

        public ActionResult Batik()
        {
            return View();
        }
        public ActionResult Pastel()
        {
            return View();
        }
    }
}