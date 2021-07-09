using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Common.Contracts;
using Common.Contracts.Repos;
using Common.Contracts.Repos.Identity ;
using Data.Repos;
using Data.Repos.Identity;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext storeContext;

        private IOrderRepository orderRepository;
        private IProductRepository productRepository;
        private ICategoryRepository categoryRepository;
        private IUserRepository userRepository;
        private IShoppingCartRepository shoppingCartRepository;
        private IShoppingCartItemRepository shoppingCartItemRepository;
        private IOrderDetailRepository orderDetailRepository;
        public UnitOfWork(StoreContext _storeContext) => storeContext = _storeContext;

        public DbContext DbContext
        {
            get { return storeContext; }
        }

        public IOrderRepository Orders
        {
            get { return orderRepository ??= new OrderRepository(storeContext); }
        }
        public IProductRepository Products
        {
            get { return productRepository ??= new ProductRepository(storeContext); }
        }
        public ICategoryRepository Categories
        {
            get { return categoryRepository ??= new CategoryRepository(storeContext); }
        }
        public IUserRepository Users
        {
            get { return userRepository ??= new UserRepository(storeContext); }
        }
        public IShoppingCartRepository ShoppingCarts
        {
            get { return shoppingCartRepository ??= new ShoppingCartRepository(storeContext); }
        }
        public IShoppingCartItemRepository ShoppingCartItems
        { 
            get { return shoppingCartItemRepository ??= new ShoppingCartItemRepository(storeContext); }
        }
        public IOrderDetailRepository OrderDetails
        {
            get { return orderDetailRepository ??= new OrderDetailRepository(storeContext); }
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
