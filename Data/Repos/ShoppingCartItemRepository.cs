using System;
using Microsoft.EntityFrameworkCore;
using Common.Contracts.Repos;
using Common.Models.Entities;
using Data.Repos.Base;


namespace Data.Repos
{
    public class ShoppingCartItemRepository : BaseRepository<Guid, ShoppingCartItem>, IShoppingCartItemRepository
    {
        public ShoppingCartItemRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
