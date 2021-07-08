using System;
using System.Collections.Generic;
using Common.Contracts.Services.Base;
using Common.Models.DTO;

namespace Common.Contracts.Services
{
    public interface IShoppingCartItemService:IService
    {
        public List<ShoppingCartItemDto> GetItems(Guid CartId);
    }
}
