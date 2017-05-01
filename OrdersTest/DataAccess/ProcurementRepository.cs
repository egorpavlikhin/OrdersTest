using System;

namespace OrdersTest.DataAccess
{
    public class ProcurementRepository : RepositoryBase<Procurement, long>, IProcurementRepository
    {
        public ProcurementRepository(OrdersTestContext dataContext) : base(dataContext)
        {
        }

        public override void Add(Procurement entity)
        {
            entity.Created = DateTime.Now;

            base.Add(entity);
        }
    }
}