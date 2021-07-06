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
            var cart = _unitOfWork.ShoppingCarts.GetById(item.ShoppingCartId);

            return false;
        }

        public void CreateCart(Guid userId)
        {
            var cartDTO = new ShoppingCartDto 
            { 
                Id = Guid.NewGuid(), 
                UserId = userId, 
                ShoppingCartItems = new List<ShoppingCartItemDto>() 
            };

            var cart = _mapper.Map<ShoppingCart>(cartDTO);
            _unitOfWork.ShoppingCarts.Add(cart);
            _unitOfWork.Commit();
        }

        public ShoppingCartDto GetCart(Guid CartId)
        {
            var cart = _unitOfWork.ShoppingCarts.GetById(CartId);

            if (cart == null)
                return null;
            return _mapper.Map<ShoppingCartDto>(cart);
        }

        public ShoppingCartDto GetCartByUser(Guid UserId)
        {
            var cart = _unitOfWork.ShoppingCarts.GetAll().FirstOrDefault(c => c.UserId == UserId);

            if (cart == null)
                return null;
            return _mapper.Map<ShoppingCartDto>(cart);
        }
    }
}
