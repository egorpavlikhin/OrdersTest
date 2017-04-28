using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OrdersTest.Models;

namespace OrdersTest.DataAccess
{
    public class OrdersTestContext : DbContext
    {
        public DbSet<Procurement> Procurements { get; set; }

        public OrdersTestContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new OrderTestDBInitializer());
        }
    }
}