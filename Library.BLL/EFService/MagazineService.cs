using AutoMapper;
using Library.DAL.Context;
using Library.DAL.EFGenericRepository;
using Library.Entities.Models;
using Library.ViewModels.Models;
using System.Collections.Generic;

namespace Library.BLL.EFService
{
    public class MagazineService
    {
        private EFGenericRepository<Magazine> _magazineRepository = new EFGenericRepository<Magazine>(new ApplicationContext());

        public IList<MagazineViewModel> GetMagazines()
        {
            var magazinesFromDb = _magazineRepository.Table;
            var magazines = Mapper.Map<IEnumerable<Magazine>, IList<MagazineViewModel>>(magazinesFromDb);
            return magazines;
        }

        public bool CreateMagazine(MagazineViewModel magazineViewModel)
        {
            try
            {
                Magazine magazine = Mapper.Map<MagazineViewModel, Magazine>(magazineViewModel);
                _magazineRepository.Create(magazine);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public MagazineViewModel GetMagazine(int id)
        {
            var magazineFromDb = _magazineRepository.FindById(id);
            var magazine = Mapper.Map<Magazine, MagazineViewModel>(magazineFromDb);
            return magazine;
        }

        public bool EditMagazine(MagazineViewModel magazineViewModel)
        {
            try
            {
                Magazine magazine = Mapper.Map<MagazineViewModel, Magazine>(magazineViewModel);
                _magazineRepository.Update(magazine);
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
                Magazine magazine = _magazineRepository.FindById(id);
                _magazineRepository.Remove(magazine);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

