using System.Data.Linq.Mapping;

namespace Library.Entities.Models
{
    public class Magazine : Publication
    {
        public int Number { get; set; }

        public int YearOfPublishing { get; set; }

        public override string ToString()
        {
            return $"{Id}. Название журнала - {Name}, количество экземпляров - {Number}, год издательства - {YearOfPublishing}.";
        }
    }
}