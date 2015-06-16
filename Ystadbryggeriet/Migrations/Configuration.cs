namespace Ystadbryggeriet.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Ystadbryggeriet.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Ystadbryggeriet.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Ystadbryggeriet.Models.ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(t => t.UserName == "admin@bryggeriet.com"))
            {
                var user = new ApplicationUser { UserName = "admin@bryggeriet.com", Email = "admin@bryggeriet.com" };
                userManager.Create(user, "passW0rd!");

                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Admin" });
                context.SaveChanges();

                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
