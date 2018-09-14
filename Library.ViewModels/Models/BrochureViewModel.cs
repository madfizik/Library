using Library.Enums;

namespace Library.ViewModels.Models
{
    public class BrochureViewModel : PublicationViewModel
    {
        public TypeOfCover TypeOfCover { get; set; }
        public int NumberOfPages { get; set; }

        public override string ToString()
        {
            return $"Книга - {Name}, автор - {TypeOfCover}, год издательства - {NumberOfPages}.";
        }
    }
}