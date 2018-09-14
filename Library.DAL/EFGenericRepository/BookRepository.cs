using Library.DAL.Context;
using Library.DAL.Filters;
using Library.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace Library.DAL.EFGenericRepository
{
    [ExceptionLogger]
    public class BookRepository : EFGenericRepository<Book>
    {
        public BookRepository(DbContext context) : base(context)
        {
        }

        [ExceptionLogger]
        public void CreateBook(Book book)
        {
            try
            {
                using (var context = new ApplicationContext())
                {
                    List<PublicationHouse> housesToAdd = new List<PublicationHouse>();
                    housesToAdd.AddRange(book.PublicationHouses);
                    book.PublicationHouses.Clear();
                    var houses = context.PublicationHouses.ToList();
                    foreach (var house in housesToAdd)
                    {
                        book.PublicationHouses.Add(houses.Find(p => p.Id == house.Id));
                    }
                    context.Books.Add(book);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [ExceptionLogger]
        public void UpdateBook(Book bookToUpdate)
        {
            try
            {
                using (var context = new ApplicationContext())
                {
                    var book = context.Books.Include("PublicationHouses").Single(b => b.Id == bookToUpdate.Id);
                    foreach (var property in book.GetType().GetProperties())
                    {
                        if (property.Name != "Id" && !property.GetGetMethod().IsVirtual)
                        {
                            property.SetValue(book, property.GetValue(bookToUpdate));
                        }
                    }
                    book.PublicationHouses.Clear();
                    var houses = context.PublicationHouses.ToList();
                    foreach (var house in bookToUpdate.PublicationHouses)
                    {
                        book.PublicationHouses.Add(houses.Find(p => p.Id == house.Id));
                    }
                    context.Entry(book).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
