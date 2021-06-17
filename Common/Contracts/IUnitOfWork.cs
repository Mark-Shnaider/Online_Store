using Common.Contracts.Repos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Common.Contracts
{
    public interface IUnitOfWork
    {
        DbContext DbContext { get; }
        IAmountRepository Amounts { get; }
        ICustomerRepository Customers { get; }
        IOrderRepository Orders{ get; }
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        void Commit();
        Task CommitAsync();
        void Rollback();
        void DetachAll();
    }
}
