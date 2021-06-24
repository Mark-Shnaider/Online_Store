using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Common.Contracts.Repos;
using Common.Contracts.Repos.Identity;

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
        IUserRepository Users { get; }
        void Commit();
        Task CommitAsync();
        void Rollback();
        void DetachAll();
    }
}
