﻿using System;
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

            var item = _mapper.Map<ShoppingCartItem>(itemDTO);

            var cart = _unitOfWork.ShoppingCarts.GetById(item.ShoppingCartId);

            var productDTO = _serviceProvider.GetRequiredService<IProductService>().GetProduct(item.Product.Id);

            if (productDTO == null)
                return false;

            Product product = _mapper.Map<Product>(productDTO);

            if (item.Amount <= product.Quantity)
            {
                if (cart.ShoppingCartItems == null)
                    cart.ShoppingCartItems = new List<ShoppingCartItem>();
                cart.ShoppingCartItems.Add(item);

                _unitOfWork.ShoppingCarts.Update(cart);
                _unitOfWork.Products.Update(product);
                _unitOfWork.Commit();
            }
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
