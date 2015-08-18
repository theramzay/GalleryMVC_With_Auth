using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
            return View();
        }

        [HttpPost]
        public ActionResult Upload(string name, string desc, string tag, string cat, decimal prc, string album,
            HttpPostedFileBase file)
        {
            if (file != null)
            {
                var pic = Path.GetFileName(file.FileName);
                var path = Path.Combine(
                    Server.MapPath($"~/Content/images/{album}/"), pic);
                var tmbpath = Path.Combine(
                    Server.MapPath($"~/Content/images/{album}/tmb"), pic);
                // file is uploaded
                file.SaveAs(path);

                ThumbnailCreater.ToTmb(path, tmbpath);

                //Upload info to DB
                var p = new Picture
                {
                    Path = $"/Content/images/{album}/{pic}",
                    TmbPath = $"/Content/images/{album}/tmb/{pic}",
                    Name = name,
                    Description = desc,
                    Tag = tag,
                    Category = album,
                    Price = prc
                };
                _repository.context.Pictures.Add(p);
                _repository.context.SaveChanges();
            }


            return View();
        }
    }
}