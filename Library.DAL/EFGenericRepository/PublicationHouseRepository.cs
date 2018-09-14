using Library.DAL.Filters;
using Library.Entities.Models;
using System.Data.Entity;

namespace Library.DAL.EFGenericRepository
{
    [ExceptionLogger]
    public class PublicationHouseRepository : EFGenericRepository<PublicationHouse>
    {
        public PublicationHouseRepository(DbContext context) : base(context)
        { }
    }
}
