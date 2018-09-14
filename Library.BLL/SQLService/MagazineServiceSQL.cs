using AutoMapper;
using Library.DAL.FileOutput;
using Library.DAL.SQLRepositories;
using Library.Entities.Models;
using Library.ViewModels.Models;
using System.Collections.Generic;

namespace Library.BLL.SQLService
{
    public class MagazineServiceSQL
    {
        private MagazineRepository _magazineRepository = new MagazineRepository();
        public IList<MagazineViewModel> GetMagazines()
        {
            Save.SaveItems(_magazineRepository.GetAll(), "../Magazines");
            var magazines =
               Mapper.Map<IList<Magazine>, IList<MagazineViewModel>>(_magazineRepository.GetAll());
            return magazines;
        }

        public bool AddMagazine(MagazineViewModel magazineViewModel)
        {
            try
            {
                Magazine magazine = Mapper.Map<MagazineViewModel, Magazine>(magazineViewModel);
                Save.AddItem(magazine, "../Magazines");
                _magazineRepository.Add(magazine);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public MagazineViewModel GetMagazine(int id)
        {
            var magazine = Mapper.Map<Magazine, MagazineViewModel>(_magazineRepository.GetAll().Find(Magazine => Magazine.Id == id));
            return magazine;
        }

        public bool EditMagazine(MagazineViewModel magazineViewModel)
        {
            try
            {
                Magazine magazine = Mapper.Map<MagazineViewModel, Magazine>(magazineViewModel);
                _magazineRepository.Edit(magazine);
                return true; 
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteMagazine(int id)
        {
            try
            {
                _magazineRepository.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}