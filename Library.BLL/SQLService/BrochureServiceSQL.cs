using AutoMapper;
using Library.DAL.FileOutput;
using Library.DAL.SQLRepositories;
using Library.Entities.Models;
using Library.ViewModels.Models;
using System.Collections.Generic;

namespace Library.BLL.SQLService
{
    public class BrochureServiceSQL
    {
        private BrochureRepository _brochureRepository = new BrochureRepository();

        public IList<BrochureViewModel> GetBrochures()
        {
            Save.SaveItems(_brochureRepository.GetAll(), "../Brochures");
            var brochures =
               Mapper.Map<IList<Brochure>, IList<BrochureViewModel>>(_brochureRepository.GetAll());
            return brochures;
        }

        public bool AddBrochure(BrochureViewModel brochureViewModel)
        {
            try
            {
                Brochure brochure = Mapper.Map<BrochureViewModel, Brochure>(brochureViewModel);
                Save.AddItem(brochure, "../Brochures");
                _brochureRepository.Add(brochure);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public BrochureViewModel GetBrochure(int id)
        {
            var brochure = Mapper.Map<Brochure, BrochureViewModel>(_brochureRepository.GetAll().Find(Brochure => Brochure.Id == id));
            return brochure;
        }

        public bool EditBrochure(BrochureViewModel brochureViewModel)
        {
            try
            {
                Brochure brochure = Mapper.Map<BrochureViewModel, Brochure>(brochureViewModel);
                _brochureRepository.Edit(brochure);
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
                _brochureRepository.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
