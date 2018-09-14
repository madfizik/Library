using AutoMapper;
using Library.DAL.Context;
using Library.DAL.EFGenericRepository;
using Library.Entities.Models;
using Library.ViewModels.Models;
using System.Collections.Generic;
using System.Linq;

namespace Library.BLL.EFService
{
    public class BookService
    {
        private BookRepository _bookRepository = new BookRepository(new ApplicationContext());
        private PublicationHouseRepository _houseRepository = new PublicationHouseRepository(new ApplicationContext());

        public IList<BookViewModel> GetBooks()
        {
            var booksFromDb = _bookRepository.Table;
            var books =
               Mapper.Map<IEnumerable<Book>, IList<BookViewModel>>(booksFromDb);
            return books;
        }

        public string GetPublicationHouseNames(ICollection<PublicationHouseViewModel> publicationHouses)
        {
            string houses = string.Empty;
            foreach (var house in publicationHouses)
            {
                houses += $"{house.Name}; ";
            }
            return houses;
        }

        public IList<PublicationHouseViewModel> GetPublicationHouses(BookViewModel book)
        {
            return book.PublicationHouses.ToList();
        }

        public bool CreateBook(AddBookViewModel addBook)
        {
            try
            {    
                var bookToAdd = Mapper.Map<AddBookViewModel, Book>(addBook);
                var housesFromDb = _houseRepository.Table.ToList();
                foreach (var house in addBook.AddPublicationHousesIds)
                {
                    bookToAdd.PublicationHouses.Add(housesFromDb.Find(p => p.Id == house));
                }
                _bookRepository.CreateBook(bookToAdd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public BookViewModel GetBook(int id)
        {
            var book = _bookRepository.FindById(id);
            var bookViewModel = Mapper.Map<Book, BookViewModel>(book);
            return bookViewModel;
        }

        public EditBookViewModel GetBookForEdit(int id)
        {
            var book = _bookRepository.FindById(id);
            var editBook = Mapper.Map<Book, EditBookViewModel>(book);
            foreach (var house in book.PublicationHouses)
            {
                editBook.EditPublicationHousesIds.Add(house.Id);
            }
            return editBook;
        }

        public bool EditBook(EditBookViewModel editBook)
        {
            try
            {
                var bookToUpdate = Mapper.Map<EditBookViewModel, Book>(editBook);
                var housesFromDb = _houseRepository.Table.ToList();
                foreach (var house in editBook.EditPublicationHousesIds)
                {
                    bookToUpdate.PublicationHouses.Add(housesFromDb.Find(p => p.Id == house));
                }
                _bookRepository.UpdateBook(bookToUpdate);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteBook(int id)
        {
            try
            {
                Book book = _bookRepository.FindById(id);
                _bookRepository.Remove(book);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

