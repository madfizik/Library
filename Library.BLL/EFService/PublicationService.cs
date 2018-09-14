using Library.ViewModels.Models;
using System.Collections.Generic;

namespace Library.BLL.EFService
{
    public class PublicationService
    {
        private BookService _bookService = new BookService();
        private BrochureService _brochureService = new BrochureService();
        private MagazineService _magazineService = new MagazineService();

        public IList<PublicationViewModel> GetPublications()
        {
            List<PublicationViewModel> publications = new List<PublicationViewModel>();
            var books = _bookService.GetBooks();
            publications.AddRange(books);
            var brochures = _brochureService.GetBrochures();
            publications.AddRange(brochures);
            var magazines = _magazineService.GetMagazines();
            publications.AddRange(magazines);
            return publications;
        }
    }
}
