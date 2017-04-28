namespace OrdersTest.DataAccess
{
    public class ProcurementRepository : RepositoryBase<Procurement, long>, IProcurementRepository
    {
        public ProcurementRepository(OrdersTestContext dataContext) : base(dataContext)
        {
        }
    }
}