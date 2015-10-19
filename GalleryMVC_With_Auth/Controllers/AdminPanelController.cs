using System.Collections.Generic;
using System.Web.Mvc;
using GalleryMVC_With_Auth.Domain.Abstract;
using GalleryMVC_With_Auth.Domain.Entities;
using GalleryMVC_With_Auth.Helpers;
using GalleryMVC_With_Auth.Models;
using GalleryMVC_With_Auth.Resources;

namespace GalleryMVC_With_Auth.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IPicturesRepository _repository;

        public AdminPanelController(IPicturesRepository repository)
        {
            _repository = repository;
        }

        [MultiAuth(UserRoles.Administrator)]
        public ActionResult Index()
        {
            return View();
        }

        [MultiAuth(UserRoles.Administrator)]
        public ActionResult Upload()
        {
            return View(_repository);
        }

        [MultiAuth(UserRoles.Administrator)]
        [HttpPost]
        public ActionResult Upload(PictureModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveImagesToDb(ImagesHelper.GetListOfPictures(model));
                return RedirectToAction("Upload");
            }
            ViewBag.alb = new List<Album>();
            return View(_repository);
        }
    }
}