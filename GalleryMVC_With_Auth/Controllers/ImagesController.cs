using System.Linq;
using System.Web.Mvc;
using GalleryMVC_With_Auth.Domain.Abstract;

namespace GalleryMVC_With_Auth.Controllers
{
    public class ImagesController : Controller
    {
        private readonly IPicturesRepository _repository;

        public ImagesController(IPicturesRepository repository)
        {
            _repository = repository;
        }

        // GET: Images
        public ActionResult Jivopis()
        {
            return View(_repository.Pictures.Where(p => p.Category == "Живопись"));
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