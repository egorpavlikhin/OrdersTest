using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersTest.DataAccess
{
    public class UserProcurementRepository : RepositoryBase<UserProcurement, string>, IUserProcurementRepository
    {
        public UserProcurementRepository(OrdersTestContext dataContext) : base(dataContext)
        {
        }

        public override UserProcurement GetById(string id)
        {
            return base.Get(x => x.UserId == id);
        }

        public IEnumerable<Procurement> GetByUserId(string userId, int skip = 0, int count = 0)
        {
            var query = base.GetMany(x => x.UserId == userId).OrderByDescending(x => x.ProcurementId).Select(x => x.Procurement).AsNoTracking();

            if (skip == 0 && count == 0)
                return query.ToList();

            if (count > 0)
            {
                return query.Skip(skip).Take(count).ToList();
            }
            else
            {
                throw new ArgumentException("count must be greater than 0, if skip parameter is set.");
            }
        }

        public async Task<Procurement> GetById(string userId, long procurementId)
        {
            var result = await base.GetAsync(x => x.UserId == userId && x.ProcurementId == procurementId).ConfigureAwait(false);

            return result?.Procurement;
        }

        public Task<int> CountAsync(string userId)
        {
            return base.GetMany(x => x.UserId == userId).CountAsync();
        }
    }
}