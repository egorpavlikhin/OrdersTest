using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OrdersTest.DataAccess;
using Ploeh.AutoFixture;

namespace OrdersTest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OrdersTest.DataAccess.OrdersTestContext>
    {
        private Fixture fixture = new Fixture();

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OrdersTest.DataAccess.OrdersTestContext context)
        {
            var manager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(
                    new OrdersTestContext()));

            for (int i = 0; i < 5; i++)
            {
                var user = new ApplicationUser()
                {
                    UserName = $"user{i}@gmail.com",
                    Email = $"user{i}@gmail.com",
                    EmailConfirmed = true
                };
                manager.Create(user, $"Password{i}");
            }

            context.Configuration.AutoDetectChangesEnabled = false;
            IList<Procurement> procurements = new List<Procurement>();
            for (int i = 0; i < 10000; i++)
            {
                var procurement = fixture.Create<Procurement>();
                procurements.Add(procurement);
                context.Procurements.Add(procurement);
            }

            context.SaveChanges();

            foreach (var procurement in procurements)
            {
                context.UserProcurements.Add(new UserProcurement { UserId = manager.FindByName("user1@gmail.com").Id, Procurement = procurement });
            }

            base.Seed(context);
        }
    }
}
