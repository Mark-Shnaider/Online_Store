using Common.Contracts;
using Common.Contracts.Repos;
using Data.Repos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext storeContext;

        private IOrderRepository orderRepository;
        private ICustomerRepository customerRepository;
        private IAmountRepository amountRepository;
        private IProductRepository productRepository;
        private ICategoryRepository categoryRepository;

        public UnitOfWork() => storeContext = new StoreContext();

        public DbContext DbContext
        {
            get { return storeContext; }
        }

        public IOrderRepository Orders
        {
            get { return orderRepository ??= new OrderRepository(storeContext); }
        }
        public ICustomerRepository Customers
        {
            get { return customerRepository ??= new CustomerRepository(storeContext); }
        }
        public IAmountRepository Amounts
        {
            get { return amountRepository ??= new AmountRepository(storeContext); }
        }
        public IProductRepository Products
        {
            get { return productRepository ??= new ProductRepository(storeContext); }
        }
        public ICategoryRepository Categories
        {
            get { return categoryRepository ??= new CategoryRepository(storeContext); }
        }

        public void Commit()
        {
            storeContext.ChangeTracker.DetectChanges();
            storeContext.SaveChanges();
        }
        public async Task CommitAsync()
        {
            storeContext.ChangeTracker.DetectChanges();
            await storeContext.SaveChangesAsync();
        }
        public void Rollback()
        {
            foreach (var entry in storeContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }
        public void DetachAll()
        {
            var entries = storeContext.ChangeTracker.Entries()
                .ToList();

            foreach (var entry in entries)
            {
                entry.State = EntityState.Detached;
            }
        }
    }
}
