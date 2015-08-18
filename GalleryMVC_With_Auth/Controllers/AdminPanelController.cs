using System;
using System.Web.Mvc;
using GalleryMVC_With_Auth.Domain.Abstract;
using GalleryMVC_With_Auth.Domain.Entities;

namespace GalleryMVC_With_Auth.Controllers
{
    public class AdminPanelController : Controller
    {

        private readonly IPicturesRepository _repository;

        public AdminPanelController(IPicturesRepository repository)
        {
            this._repository = repository;
        }

        // GET: AdminPanel
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(string path, string tmbpath, string name, string desc,string tag, string cat, decimal prc)
        {
            Picture p = new Picture()
            {
                Path = path,
                TmbPath = tmbpath,
                Name = name,
                Description = desc,
                Tag = tag,
                Category = cat,
                Price = prc
            };
            _repository.context.Pictures.Add(p);
            _repository.context.SaveChanges();
            return View();
        }
    }
}