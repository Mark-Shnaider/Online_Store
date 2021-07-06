using System;
using Common.Contracts.Repos.Base;
using Common.Models.Entities;

namespace Common.Contracts.Repos
{
    public interface IShoppingCartRepository : IBaseRepository<Guid, ShoppingCart>
    {
        public ShoppingCart GetByUserId(Guid Id);
    }
}
