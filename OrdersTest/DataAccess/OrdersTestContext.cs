using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OrdersTest.Models;

namespace OrdersTest.DataAccess
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    public class OrdersTestContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Procurement> Procurements { get; set; }

        public DbSet<UserProcurement> UserProcurements { get; set; }

        public OrdersTestContext() : base("DefaultConnection")
        {
        }

        public static OrdersTestContext Create()
        {
            return new OrdersTestContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProcurement>()
                .HasKey(u => new { u.UserId, u.ProcurementId });

            base.OnModelCreating(modelBuilder);
        }
    }
}