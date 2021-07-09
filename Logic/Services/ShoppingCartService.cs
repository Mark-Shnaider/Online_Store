using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
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

        public bool AddToCart(ShoppingCartItemDto itemDTO)
        {
            if (itemDTO == null)
                return false;

            _unitOfWork.DetachAll();

            var item = _mapper.Map<ShoppingCartItem>(itemDTO);

            item.Product.Quantity -= item.Amount;
            _unitOfWork.Products.AddOrUpdate(item.Product);

            var find_item = _unitOfWork.ShoppingCartItems.GetAll()
                .FirstOrDefault(i => i.ShoppingCartId == item.ShoppingCartId && i.ProductId == item.Product.Id);

            if (find_item != null)
            {
                find_item.Amount += item.Amount;
                _unitOfWork.ShoppingCartItems.AddOrUpdate(find_item);
            }
            else
            { 
                _unitOfWork.ShoppingCartItems.Add(item);
            }
            _unitOfWork.Commit();

            return true;
        }

        public bool RemoveFromCart(ShoppingCartItemDto itemDTO)
        {
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
            var cart = _unitOfWork.ShoppingCarts
                .GetAll()
                .Include(c => c.ShoppingCartItems)
                .FirstOrDefault(c => c.Id == CartId);

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
