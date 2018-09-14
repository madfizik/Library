using Library.BLL.EFService;
using Library.BLL.Infrastructure;
using Library.Enums;
using Library.ViewModels.Models;
using System.Collections.Generic;
using System.Linq;

using System.Web.Mvc;

namespace Library.WEB.Controllers
{
    public class BookController : Controller
    {
        private BookService _bookService = new BookService();
        private PublicationHouseService _houseService = new PublicationHouseService();

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetBooks()
        {
            var data = _bookService.GetBooks().OrderByDescending(b => b.Name).Select(b => new
            {
                ID = b.Id,
                b.Name,
                b.Author,
                b.YearOfPublishing,
                PublicationHouses = _bookService.GetPublicationHouseNames(b.PublicationHouses)
            }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPublicationHouses()
        {
            var data = _houseService.GetPublicationHouses().OrderByDescending(p => p.Name).Select(p => new
            {
                p.Id,
                p.Name
            }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetBookPublicationHouses(int bookId)
        {
            var book = _bookService.GetBook(bookId);
            var data = book.PublicationHouses.OrderByDescending(p => p.Name).Select(p => p.Id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = nameof(LibraryRoles.Admin))]
        public ActionResult AddBook()
        {
            AddBookViewModel addBook = new AddBookViewModel();
            foreach (var house in _houseService.GetPublicationHouses())
            {
                addBook.AddPublicationHousesIds.Add(house.Id);
            }
            return View(addBook);
        }

        [Authorize(Roles=nameof(LibraryRoles.Admin))]
        [HttpPost]
        public ActionResult AddBook(AddBookViewModel addBook)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bookService.CreateBook(addBook);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = nameof(LibraryRoles.Admin))]
        public ActionResult EditBook(int id)
        {
            var book = _bookService.GetBookForEdit(id);
            return View(book);
        }

        [Authorize(Roles = nameof(LibraryRoles.Admin))]
        [HttpPost]
        public ActionResult EditBook(EditBookViewModel editBook)
        {
            try
            {
                _bookService.EditBook(editBook);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = nameof(LibraryRoles.Admin))]
        public ActionResult DeleteBook(int id)
        {
            try
            {
                _bookService.DeleteBook(id);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
    }
}