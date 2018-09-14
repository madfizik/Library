using AutoMapper;
using Library.DAL.FileOutput;
using Library.DAL.Repositories;
using Library.Entities.Models;
using Library.ViewModels.Models;
using System.Collections.Generic;

namespace Library.BLL.SQLService
{
    public class BookServiceSQL
    {
        private BookRepository _bookRepository = new BookRepository();
 
        public IList<BookViewModel> GetBooks()
        {
            Save.SaveItems(_bookRepository.GetAll(), "../Books");
            var books =
               Mapper.Map<IList<Book>, IList<BookViewModel>>(_bookRepository.GetAll());
            return books;
        }

        public bool AddBook(BookViewModel bookViewModel)
        {
            try
            {
                Book book = Mapper.Map<BookViewModel, Book>(bookViewModel);
                Save.AddItem(book, "../Books");
                _bookRepository.Add(book);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public BookViewModel GetBook(int id)
        {
            var book = Mapper.Map<Book, BookViewModel>(_bookRepository.GetAll().Find(b => b.Id == id));
            return book;
        }

        public bool EditBook(BookViewModel bookViewModel)
        {
            try
            {
                Book book = Mapper.Map<BookViewModel, Book>(bookViewModel);
                _bookRepository.Edit(book);
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
                _bookRepository.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
