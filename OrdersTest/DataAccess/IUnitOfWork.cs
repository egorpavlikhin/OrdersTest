using System.Threading.Tasks;

namespace OrdersTest.DataAccess
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
        void Rollback();
    }
}