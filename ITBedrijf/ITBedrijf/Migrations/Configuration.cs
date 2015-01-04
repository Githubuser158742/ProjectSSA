namespace ITBedrijf.Migrations
{
    using ITBedrijf.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ITBedrijf.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ITBedrijf.Models.ApplicationDbContext context)
        {
            string roleAdmin = "Administrator";
            string roleNormalUser = "User";
            IdentityResult roleResult;
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!RoleManager.RoleExists(roleNormalUser))
            {
                roleResult = RoleManager.Create(new IdentityRole(roleNormalUser));
            }
            if (!RoleManager.RoleExists(roleAdmin))
            {
                roleResult = RoleManager.Create(new IdentityRole(roleAdmin));
            }
            if (!context.Users.Any(u => u.Email.Equals("jim.butseraen@gmail.com")))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                {
                    FirstName = "Jim",
                    Name = "Butseraen",
                    Email = "jim.butseraen@gmail.com",
                    UserName = "jim.butseraen@gmail.com",
                    Address = "Petuniaslaan",
                    City = "Koksijde",
                    Zipcode = "8670",
                    TwitterName = "@JimButseraen"
                };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, roleAdmin);
            }
        }
    }
}
