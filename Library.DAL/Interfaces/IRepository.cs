using Library.Entities.Models;
using System.Collections.Generic;

namespace Library.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    { 
        bool Add(T publication);
        List<T> GetAll();
        bool Edit(T publication);
        bool Delete(int id);
    }
}

