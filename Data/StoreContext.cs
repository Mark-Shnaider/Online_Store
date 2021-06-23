using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Common.Models.Entities;
using Common.Models.Entities.Identity;

namespace Data
{
    public class StoreContext : IdentityDbContext<User>
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
