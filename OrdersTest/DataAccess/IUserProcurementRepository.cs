using System.Collections.Generic;

namespace OrdersTest.DataAccess
{
    public interface IUserProcurementRepository : IRepository<UserProcurement, string>
    {
        IEnumerable<Procurement> GetByUserId(string userId, int skip = 0, int count = 0);
    }
}