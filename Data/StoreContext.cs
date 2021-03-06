using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Common.Models.Entities;
using Common.Models.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Data
{
    public class StoreContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
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
        DbSet<Order> Orders { get; set; }
        DbSet<ShoppingCart> ShoppingCarts { get; set; }
        DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
