using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RememberMeBackend.Models.Data;
using System;

namespace RememberMeBackend.Data {
    public class MemoriesInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MemoryDbContext> {
        protected override void Seed(MemoryDbContext context) {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            ApplicationUser user = new ApplicationUser {
                Id = Guid.NewGuid().ToString("D"),
                UserFirstName = "Janikka",
                UserLastName = "Peeters",
                UserQuestion1 = "Q1?",
                UserAnswer1 = "A1",
                UserQuestion2 = "Q2?",
                UserAnswer2 = "A2",
                UserName = "JPeeters",
                PasswordHash = userManager.PasswordHasher.HashPassword("somethingsomething54!"),
            };
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}