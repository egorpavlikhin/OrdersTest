using System;
using System.Threading.Tasks;

namespace OrdersTest.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private OrdersTestContext dbContext;

        public UnitOfWork(OrdersTestContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void BeginTransaction()
        {
            ;
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return dbContext.SaveChangesAsync();
        }

        public void Rollback()
        {
        }
    }
}