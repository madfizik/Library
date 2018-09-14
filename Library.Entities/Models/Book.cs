using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace Library.Entities.Models
{
    public class Book : Publication
    {
        public string Author { get; set; }

        public int YearOfPublishing { get; set; }

        public virtual ICollection<PublicationHouse> PublicationHouses { get; set; }

        public Book()
        {
            PublicationHouses = new List<PublicationHouse>();
        }

        public override string ToString()
        {
            string book = $"{Id}. Название книги - {Name}, автор - {Author}, год издательства - {YearOfPublishing}";
            return book;
        }
    }
}