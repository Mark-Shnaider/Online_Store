using System;
using System.Collections.Generic;
using Common.Contracts.Services.Base;
using Common.Models.DTO;

namespace Common.Contracts.Services
{
    public interface IShoppingCartService:IService
    {
        public bool AddToCart(ShoppingCartItemDto item);
        public ShoppingCartDto GetCart(Guid CartId);
        public ShoppingCartDto GetCartByUser(Guid UserId);
        public void CreateCart(Guid UserId);
    }
}
