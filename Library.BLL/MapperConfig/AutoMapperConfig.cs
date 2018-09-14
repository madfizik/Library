using AutoMapper;
using Library.Entities.Models;
using Library.ViewModels.Models;

namespace Library.BLL.MapperConfig
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Book, BookViewModel>();
                cfg.CreateMap<BookViewModel, Book>();
                cfg.CreateMap<Book, AddBookViewModel>();
                cfg.CreateMap<AddBookViewModel, Book>();
                cfg.CreateMap<Book, EditBookViewModel>();
                cfg.CreateMap<EditBookViewModel, Book>();
                cfg.CreateMap<Brochure, BrochureViewModel>();
                cfg.CreateMap<Magazine, MagazineViewModel>();
                cfg.CreateMap<PublicationHouse, PublicationHouseViewModel>();
                cfg.CreateMap<PublicationHouseViewModel, PublicationHouse>();
            });
        }
    }
}
