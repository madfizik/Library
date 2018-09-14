using Library.BLL.EFService;
using Library.BLL.Infrastructure;
using Library.Enums;
using Library.ViewModels.Models;
using System.Linq;
using System.Web.Mvc;

namespace Library.WEB.Controllers
{
    public class BrochureController : Controller
    {
        private BrochureService _brochureService = new BrochureService();

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetBrochures()
        {
            var data = _brochureService.GetBrochures().OrderByDescending(b => b.Name).Select(b => new
            {
                ID = b.Id,
                b.Name,
                TypeOfCover = b.TypeOfCover.ToString(),
                b.NumberOfPages,
            }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = nameof(LibraryRoles.Admin))]
        public ActionResult AddBrochure()
        {
            return View();
        }

        [Authorize(Roles = nameof(LibraryRoles.Admin))]
        [HttpPost]
        public ActionResult AddBrochure(BrochureViewModel brochureViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _brochureService.CreateBrochure(brochureViewModel);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = nameof(LibraryRoles.Admin))]
        public ActionResult EditBrochure(int id)
        {
            return View(_brochureService.GetBrochure(id));
        }

        [Authorize(Roles = nameof(LibraryRoles.Admin))]
        [HttpPost]
        public ActionResult EditBrochure(int id, BrochureViewModel brochureViewModel)
        {
            try
            {
                _brochureService.EditBrochure(brochureViewModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = nameof(LibraryRoles.Admin))]
        public ActionResult DeleteBrochure(int id)
        {
            try
            {
                _brochureService.DeleteBrochure(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
