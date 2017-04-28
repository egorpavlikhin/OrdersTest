using System.Collections.Generic;
using System.Data.Entity;
using Ploeh.AutoFixture;

namespace OrdersTest.DataAccess
{
    public class OrderTestDBInitializer : DropCreateDatabaseAlways<OrdersTestContext>
    {
        protected override void Seed(OrdersTestContext context)
        {
            var fixture = new Fixture();
            IList<Procurement> procurements = new List<Procurement>();

            for (int i = 0; i < 10000; i++)
            {
                procurements.Add(fixture.Create<Procurement>());
            }

            foreach (Procurement procurement in procurements)
                context.Procurements.Add(procurement);

            base.Seed(context);
        }
    }
}