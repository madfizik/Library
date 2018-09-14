using Library.BLL.EFService;
using Library.Enums;
using System.Linq;
using System.Web.Mvc;

namespace Library.WEB.Controllers
{
    public class PublicationController : Controller
    {
        private PublicationService _libraryService = new PublicationService();

        public ActionResult GetPublications()
        {
            var data = _libraryService.GetPublications().OrderByDescending(b => b.Name).Select(b => new
            {
                ID = b.Id,
                b.Name,
                Type = b.GetType().Name.Replace("ViewModel", "")
            }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}