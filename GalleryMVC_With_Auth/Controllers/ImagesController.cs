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

        public ActionResult Universal(int Id)
        {
            return View(_repository.Pictures.Where(p => p.AlbumId == Id));
        }
    }
}