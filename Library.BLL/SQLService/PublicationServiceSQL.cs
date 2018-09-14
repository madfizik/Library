using Library.DAL.FileOutput;
using Library.ViewModels.Models;
using System.Collections.Generic;

namespace Library.BLL.SQLService
{
    public class PublicationServiceSQL
    { 
        private BookServiceSQL _bookService = new BookServiceSQL();
        private BrochureServiceSQL _brochureService = new BrochureServiceSQL();
        private MagazineServiceSQL _magazineService = new MagazineServiceSQL();

        public IList<PublicationViewModel> GetPublication()
        {
            List<PublicationViewModel> publications = new List<PublicationViewModel>();
            publications.AddRange(_bookService.GetBooks());
            publications.AddRange(_brochureService.GetBrochures());
            publications.AddRange(_magazineService.GetMagazines());
            Save.SaveItems<PublicationViewModel>(publications, "../Publications");
            return publications;
        }
    }
}