using System.Collections.Generic;

namespace Library.Entities.Models
{
    public class PublicationHouse 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public PublicationHouse()
        {
            Books = new List<Book>();
        }

        public override string ToString()
        {
            string house = $"{Id}. Название издательства - {Name}, адрес - {Adress}";
            return house;
        }
    }
}
