using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Common.Contracts.Repos;
using Common.Models.Entities;
using Data.Repos.Base;

namespace Data.Repos
{
    public class ShoppingCartRepository : BaseRepository<Guid, ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(DbContext dbContext) : base(dbContext)
        {
            
        }
        public ShoppingCart GetByUserId(Guid Id)
        {
            var cart = DbSet.FirstOrDefault(c => c.UserId == Id);

            return cart ?? new ShoppingCart { UserId = Id, Id = Guid.NewGuid(), ShoppingCartItems = new List<ShoppingCartItem>()};
        }
    }
}
