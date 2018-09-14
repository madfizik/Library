using Library.Enums;

namespace Library.Entities.Models
{
    public class Brochure : Publication
    {
        public TypeOfCover TypeOfCover { get; set; }

        public int NumberOfPages { get; set; }

        public override string ToString()
        {
            return $"{Id}. Название брошуры - {Name}, тип - {TypeOfCover}, кол-во страниц - {NumberOfPages}.";
        }
    }
}