using Library.DAL.Filters;
using Library.Entities.Models;
using System.Data.Entity;

namespace Library.DAL.EFGenericRepository
{
    [ExceptionLogger]
    public class BrochureRepository : EFGenericRepository<PublicationHouse>
    {
        public BrochureRepository(DbContext context) : base(context)
        { }
    }
}
