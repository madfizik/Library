using Library.DAL.Repositories;
using Library.Entities.Models;
using Library.Enums;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Library.DAL.Context
{
    public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            Book book = new Book
            {
                Name = "Война и мир",
                Author = "Л. Толстой",
                YearOfPublishing = 1998
            };
            PublicationHouse house = new PublicationHouse
            {
                Name = "qwerty",
                Adress = "Tales-Street"
            };
            house.Books.Add(book);
            book.PublicationHouses.Add(house);
            context.Books.Add(new Book { Name = "Отцы и дети", Author = "И. Тургенев", YearOfPublishing = 2016, PublicationHouses = new List<PublicationHouse> { house } });
            context.Books.Add(new Book { Name = "Чайка", Author = "А. Чехов", YearOfPublishing = 2015, PublicationHouses = new List<PublicationHouse> { house } });
            context.Books.Add(book);
            context.Magazines.Add(new Magazine { Name = "Forbes", Number = 20, YearOfPublishing = 2012 });
            context.Magazines.Add(new Magazine { Name = "Biography", Number = 10, YearOfPublishing = 1960 });
            context.Magazines.Add(new Magazine { Name = "Times", Number = 9, YearOfPublishing = 1880 });
            context.Brochures.Add(new Brochure { Name = "asd", TypeOfCover = TypeOfCover.Soft, NumberOfPages = 123 });
            context.PublicationHouses.Add(house);
            context.PublicationHouses.Add(new PublicationHouse { Name = "asd", Adress = "asd", Books = new List<Book> { book } });
            var passwordHasher = new PasswordHasher();
            var user = new ApplicationUser { Email = "madfiz18@gmail.com", UserName = "madfiz18@gmail.com" }; 
            user.PasswordHash = passwordHasher.HashPassword("14921875");
            user.SecurityStamp = Guid.NewGuid().ToString();
            var adminRole = new ApplicationRole { Name = LibraryRoles.Admin.ToString() };
            context.Roles.Add(adminRole);
            var userRole = new ApplicationRole { Name = LibraryRoles.User.ToString() };
            context.Roles.Add(userRole);
            var role = new IdentityUserRole
            {
                RoleId = adminRole.Id,
                UserId = user.Id
            };
            ClientProfile clientProfile = new ClientProfile { Id = user.Id, Address = "ул. Спортивная, д.30, кв.75", Name = "Будько Александр Алексеевич" };
            context.ClientProfiles.Add(clientProfile);
            user.Roles.Add(role);
            context.Users.Add(user);
            base.Seed(context);
        }
    }
}