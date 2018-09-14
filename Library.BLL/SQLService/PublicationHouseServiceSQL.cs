using AutoMapper;
using Library.DAL.FileOutput;
using Library.DAL.SQLRepositories;
using Library.Entities.Models;
using Library.ViewModels.Models;
using System.Collections.Generic;

namespace Library.BLL.ServiceSQL
{
    public class PublicationHouseServiceSQL
    {
        private PublicationHouseRepository _publicationHouseRepository = new PublicationHouseRepository();
        public IList<PublicationHouseViewModel> GetPublicationHouses()
        {
            Save.SaveItems(_publicationHouseRepository.GetAll(), "../PublicationHouses");
            var publicationHouses =
               Mapper.Map<IList<PublicationHouse>, IList<PublicationHouseViewModel>>(_publicationHouseRepository.GetAll());
            return publicationHouses;
        }

        public bool AddPublicationHouse(PublicationHouseViewModel publicationHouseViewModel)
        {
            try
            {
                PublicationHouse publicationHouse = Mapper.Map<PublicationHouseViewModel, PublicationHouse>(publicationHouseViewModel);
                Save.AddItem(publicationHouse, "../PublicationHouses");
                _publicationHouseRepository.Add(publicationHouse);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public PublicationHouseViewModel GetPublicationHouse(int id)
        {
            var publicationHouse = Mapper.Map<PublicationHouse, PublicationHouseViewModel>(_publicationHouseRepository.GetAll().Find(PublicationHouse => PublicationHouse.Id == id));
            return publicationHouse;
        }

        public bool EditPublicationHouse(PublicationHouseViewModel publicationHouseViewModel)
        {
            try
            {
                PublicationHouse publicationHouse = Mapper.Map<PublicationHouseViewModel, PublicationHouse>(publicationHouseViewModel);
                _publicationHouseRepository.Edit(publicationHouse);
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
                _publicationHouseRepository.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
