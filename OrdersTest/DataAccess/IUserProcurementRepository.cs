using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersTest.DataAccess
{
    public interface IUserProcurementRepository : IRepository<UserProcurement, string>
    {
        IEnumerable<Procurement> GetByUserId(string userId, int skip = 0, int count = 0);
        Task<Procurement> GetById(string userId, long procurementId);
        Task<int> CountAsync(string userId);
    }
}