﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ystadbryggeriet.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public string Name { get; set; }
        public string Role { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<PageModel> PageModels { get; set; }

        public System.Data.Entity.DbSet<Ystadbryggeriet.Models.Happenings> Happenings { get; set; }

        public System.Data.Entity.DbSet<Ystadbryggeriet.Models.Question> Questions { get; set; }

        public System.Data.Entity.DbSet<Ystadbryggeriet.Models.Test> Tests { get; set; }

        public System.Data.Entity.DbSet<Ystadbryggeriet.Models.Message> Messages { get; set; }

        public System.Data.Entity.DbSet<Ystadbryggeriet.Models.CalendarEvent> CalendarEvents { get; set; }



    }
}