using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Common.Models.DTO;
using Common.Models.Entities;
using Common.Contracts;
using Common.Contracts.Services;
using Logic.Services.Base;


namespace Logic.Services
{
    public class ShoppingCartService : BaseService, IShoppingCartService
    {
        public ShoppingCartService(IMapper mapper, IServiceProvider serviceProvider, IUnitOfWork unitOfWork)
            : base(mapper, serviceProvider, unitOfWork)
        {

        }

        public bool AddToCart(ShoppingCartItemDto item)
        {
            var cart = _unitOfWork.ShoppingCarts.GetByUserId(item.ShoppingCartId);

            return false;
        }

        public ShoppingCartDto GetOrCreateCart(Guid Id)
        {
            var cart = _unitOfWork.ShoppingCarts.GetByUserId(Id);

            return _mapper.Map<ShoppingCartDto>(cart);
        }
    }
}
