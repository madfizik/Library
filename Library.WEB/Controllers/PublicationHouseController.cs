using Library.BLL.EFService;
using Library.BLL.Infrastructure;
using Library.Enums;
using Library.ViewModels.Models;
using System.Linq;
using System.Web.Mvc;

namespace Library.WEB.Controllers
{
    public class PublicationHouseController : Controller
    {
        private PublicationHouseService _publicationHouseService = new PublicationHouseService();
        private BookService _bookService = new BookService();

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPublicationHouses()
        {
            var data = _publicationHouseService.GetPublicationHouses().OrderByDescending(p => p.Name).Select(P => new
            {
                ID = P.Id,
                P.Name,
                P.Adress,
                Books = _publicationHouseService.GetBooksNames(P.Books)
            }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = nameof(LibraryRoles.Admin))]
        public ActionResult AddPublicationHouse()
        {
            return View();
        }

        [Authorize(Roles = nameof(LibraryRoles.Admin))]
        [HttpPost]
        public ActionResult AddPublicationHouse(PublicationHouseViewModel PublicationHouseViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _publicationHouseService.CreatePublicationHouse(PublicationHouseViewModel);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = nameof(LibraryRoles.Admin))]
        public ActionResult EditPublicationHouse(int id)
        {
            return View(_publicationHouseService.GetPublicationHouse(id));
        }

        [Authorize(Roles = nameof(LibraryRoles.Admin))]
        [HttpPost]
        public ActionResult EditPublicationHouse(PublicationHouseViewModel PublicationHouseViewModel)
        {
            try
            {
                _publicationHouseService.EditPublicationHouse(PublicationHouseViewModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = nameof(LibraryRoles.Admin))]
        public ActionResult DeletePublicationHouse(int id)
        {
            try
            {
                _publicationHouseService.DeletePublicationHouse(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

