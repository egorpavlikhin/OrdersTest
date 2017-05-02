using System.Threading.Tasks;

namespace OrdersTest.DataAccess
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        int Commit();
        Task<int> CommitAsync();
        void Rollback();
    }
}