using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GalleryMVC_With_Auth.Domain.Abstract;
using GalleryMVC_With_Auth.Domain.Entities;
using GalleryMVC_With_Auth.Helpers;

namespace GalleryMVC_With_Auth.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IPicturesRepository _repository;

        public AdminPanelController(IPicturesRepository repository)
        {
            _repository = repository;
        }

        // GET: AdminPanel
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            ViewBag.alb = new List<Album>();
            foreach (Album a in _repository.Albums)
            {
                ViewBag.alb.Add(a);
            }
            return View(_repository);
        }

        [HttpPost]
        public ActionResult Upload(string name, string desc, string tag, string cat, decimal prc, int Albums,
            HttpPostedFileBase file)
        {
            if (file != null)
            {
                var pic = Path.GetFileName(file.FileName);
                var path = Path.Combine(
                    Server.MapPath($"~/Content/images/{_repository.Albums.Where(x=>x.AlbId == Albums).Select(x=>x.Name).FirstOrDefault()}/"), pic);
                var tmbpath = Path.Combine(
                    Server.MapPath($"~/Content/images/{_repository.Albums.Where(x => x.AlbId == Albums).Select(x => x.Name).FirstOrDefault()}/tmb"), pic);
                // file is uploaded
                file.SaveAs(path);

                ThumbnailCreater.ToTmb(path, tmbpath);

                //Upload info to DB
                var p = new Picture
                {
                    Path = $"/Content/images/{_repository.Albums.Where(x => x.AlbId == Albums).Select(x => x.Name).FirstOrDefault()}/{pic}",
                    TmbPath = $"/Content/images/{_repository.Albums.Where(x => x.AlbId == Albums).Select(x => x.Name).FirstOrDefault()}/tmb/{pic}",
                    Name = name,
                    Description = desc,
                    Tag = tag,
                    Category = "blob",
                    Price = prc,
                    AlbumAlbId = Albums
                };
                _repository.context.Pictures.Add(p);
                _repository.context.SaveChanges();
            }

            return RedirectToAction("Upload");
        }
    }
}