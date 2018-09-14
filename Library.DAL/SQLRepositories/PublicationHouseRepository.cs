using Library.DAL.Interfaces;
using Library.Entities.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Linq;

namespace Library.DAL.SQLRepositories
{
    public class PublicationHouseRepository : IRepository<PublicationHouse>
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["LibraryContext"].ToString();
        private DataContext _dataContext = new DataContext(_connectionString);

        public bool Add(PublicationHouse publicationHouse)
        {
            try
            {
                _dataContext.GetTable<PublicationHouse>().InsertOnSubmit(publicationHouse);
                _dataContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<PublicationHouse> GetAll()
        {
            Table<PublicationHouse> publicationHouses = _dataContext.GetTable<PublicationHouse>();
            return publicationHouses.ToList();
        }

        public bool Edit(PublicationHouse publicationHouse)
        {
            try
            {
                publicationHouse = (PublicationHouse)_dataContext.GetTable<PublicationHouse>().Where(pb => pb.Id == publicationHouse.Id);
                publicationHouse.Name = publicationHouse.Name;
                publicationHouse.Adress = publicationHouse.Adress;
                _dataContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var publicationHouse = (PublicationHouse)_dataContext.GetTable<PublicationHouse>().Where(pb => pb.Id == id);

                if (publicationHouse != null)
                {
                    _dataContext.GetTable<PublicationHouse>().DeleteOnSubmit(publicationHouse);
                    _dataContext.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
