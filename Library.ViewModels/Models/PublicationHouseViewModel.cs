using System.Collections.Generic;

namespace Library.ViewModels.Models
{
    public class PublicationHouseViewModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public virtual ICollection<BookViewModel> Books { get; set; }
    }
}
