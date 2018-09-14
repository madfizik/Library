using Library.DAL.Filters;
using Library.Entities.Models;
using System.Data.Entity;

namespace Library.DAL.EFGenericRepository
{
    [ExceptionLogger]
    public class MagazineRepository : EFGenericRepository<Magazine>
    {
        public MagazineRepository(DbContext context) : base(context)
        { }
    }
}
