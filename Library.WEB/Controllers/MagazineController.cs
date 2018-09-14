using Library.BLL.EFService;
using Library.BLL.Infrastructure;
using Library.Enums;
using Library.ViewModels.Models;
using System.Linq;
using System.Web.Mvc;

namespace Library.WEB.Controllers
{
    public class MagazineController : Controller
    {
        private MagazineService _magazineService = new MagazineService();

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMagazines()
        {
            var data = _magazineService.GetMagazines().OrderByDescending(b => b.Name).Select(b => new
            {
                ID = b.Id,
                b.Name,
                b.Number,
                b.YearOfPublishing,
            }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = nameof(LibraryRoles.Admin))]
        public ActionResult AddMagazine()
        {
            return View();
        }

        [Authorize(Roles = nameof(LibraryRoles.Admin))]
        [HttpPost]
        public ActionResult AddMagazine(MagazineViewModel magazineViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _magazineService.CreateMagazine(magazineViewModel);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = nameof(LibraryRoles.Admin))]
        public ActionResult EditMagazine(int id)
        {
            return View(_magazineService.GetMagazine(id));
        }

        [Authorize(Roles = nameof(LibraryRoles.Admin))]
        [HttpPost]
        public ActionResult EditMagazine(MagazineViewModel magazineViewModel)
        {
            try
            {
                _magazineService.EditMagazine(magazineViewModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = nameof(LibraryRoles.Admin))]
        public ActionResult DeleteMagazine(int id)
        {
            try
            {
                _magazineService.DeleteMagazine(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}