namespace Library.DAL.Migrations
{
    using Library.DAL.Context;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Library.DAL.Context.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Library.DAL.Context.ApplicationContext";
        }

        protected override void Seed(Library.DAL.Context.ApplicationContext context)
        {
            Database.SetInitializer(new ApplicationDbInitializer());
        }
    }
}
