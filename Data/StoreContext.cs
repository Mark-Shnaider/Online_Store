using Common.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class StoreContext : DbContext
    {
        public StoreContext()
        { 
        
        }
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {

        }
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Amount> Amounts { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Customer> Customers { get; set; }

    }
}
