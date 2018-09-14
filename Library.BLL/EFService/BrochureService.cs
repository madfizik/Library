using AutoMapper;
using Library.DAL.Context;
using Library.DAL.EFGenericRepository;
using Library.Entities.Models;
using Library.ViewModels.Models;
using System.Collections.Generic;

namespace Library.BLL.EFService
{
    public class BrochureService
    {
        private EFGenericRepository<Brochure> _brochureRepository = new EFGenericRepository<Brochure>(new ApplicationContext());

        public IList<BrochureViewModel> GetBrochures()
        {
            var brochuresFromDb = _brochureRepository.Table;
            var brochures = Mapper.Map<IEnumerable<Brochure>, IList<BrochureViewModel>>(brochuresFromDb);
            return brochures;
        }

        public bool CreateBrochure(BrochureViewModel brochureViewModel)
        {
            try
            {
                Brochure brochure = Mapper.Map<BrochureViewModel, Brochure>(brochureViewModel);
                _brochureRepository.Create(brochure);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public BrochureViewModel GetBrochure(int id)
        {
            var brochureFromDb = _brochureRepository.FindById(id);
            var brochure = Mapper.Map<Brochure, BrochureViewModel>(brochureFromDb);
            return brochure;
        }

        public bool EditBrochure(BrochureViewModel brochureViewModel)
        {
            try
            {
                Brochure brochure = Mapper.Map<BrochureViewModel, Brochure>(brochureViewModel);
                _brochureRepository.Update(brochure);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteBrochure(int id)
        {
            try
            {
                Brochure brochure = _brochureRepository.FindById(id);
                _brochureRepository.Remove(brochure);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

