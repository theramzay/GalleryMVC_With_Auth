using System.Linq;
using System.Web.Mvc;
using GalleryMVC_With_Auth.Models;
using GalleryMVC_With_Auth.Resources;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GalleryMVC_With_Auth.Controllers
{
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RolesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Roles
        /// <summary>
        ///     Get All Roles
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(_context.Roles.ToList());
        }

        /// <summary>
        ///     Create  a New role
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View(new IdentityRole());
        }

        /// <summary>
        ///     Create a New Role
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            _context.Roles.Add(Role);
            _context.SaveChanges();
            return RedirectToAction(Defines.IndexView);
        }
    }
}