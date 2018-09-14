using System.Collections.Generic;

namespace Library.ViewModels.Models
{
    public class BookViewModel : PublicationViewModel
    {
        public int YearOfPublishing { get; set; }
        public string Author { get; set; }
        public virtual ICollection<PublicationHouseViewModel> PublicationHouses { get; set; }
    }
}