using System;
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
    }
}
