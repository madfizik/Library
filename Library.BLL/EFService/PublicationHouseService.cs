using AutoMapper;
using Library.DAL.Context;
using Library.DAL.EFGenericRepository;
using Library.Entities.Models;
using Library.ViewModels.Models;
using System.Collections.Generic;

namespace Library.BLL.EFService
{
    public class PublicationHouseService
    {
        private EFGenericRepository<PublicationHouse> _houseRepository = new EFGenericRepository<PublicationHouse>(new ApplicationContext());

        public IList<PublicationHouseViewModel> GetPublicationHouses()
        {
            var housesFromDb = _houseRepository.Table;
            var publicationHouses = Mapper.Map<IEnumerable<PublicationHouse>, IList<PublicationHouseViewModel>>(housesFromDb);
            return publicationHouses;
        }

        public bool CreatePublicationHouse(PublicationHouseViewModel publicationHouseViewModel)
        {
            try
            {
                PublicationHouse publicationHouse = Mapper.Map<PublicationHouseViewModel, PublicationHouse>(publicationHouseViewModel);
                _houseRepository.Create(publicationHouse);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetBooksNames(ICollection<BookViewModel> booksView)
        {
            string books = string.Empty;
            foreach (var book in booksView)
            {
                books += $"{book.Name}; ";
            }
            return books;
        }

        public PublicationHouseViewModel GetPublicationHouse(int id)
        {
            var houseFromDb = _houseRepository.FindById(id);
            var publicationHouse = Mapper.Map<PublicationHouse, PublicationHouseViewModel>(houseFromDb);
            return publicationHouse;
        }

        public bool EditPublicationHouse(PublicationHouseViewModel publicationHouseViewModel)
        {
            try
            {
                PublicationHouse publicationHouse = Mapper.Map<PublicationHouseViewModel, PublicationHouse>(publicationHouseViewModel);
                _houseRepository.Update(publicationHouse);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePublicationHouse(int id)
        {
            try
            {
                PublicationHouse publicationHouse = _houseRepository.FindById(id);
                _houseRepository.Remove(publicationHouse);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

