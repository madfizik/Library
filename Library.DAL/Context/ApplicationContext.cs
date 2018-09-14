using Library.Entities.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Library.DAL.Context
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Brochure> Brochures { get; set; }
        public DbSet<PublicationHouse> PublicationHouses { get; set; }
        public DbSet<ExceptionDetail> ExceptionDetails { get; set; }

        public ApplicationContext() : base("LibraryContext") { }
    }
}
