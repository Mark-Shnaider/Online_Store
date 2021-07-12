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
using Common.Contracts.Repos;

namespace Logic.Services
{
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(IMapper mapper, IServiceProvider serviceProvider, IUnitOfWork unitOfWork)
            : base(mapper, serviceProvider, unitOfWork)
        {

        }
        public void CreateOrder(OrderDto orderDTO)
        {
            var user = _unitOfWork.Users.GetAll()
                .Include(u => u.ShoppingCart)
                .ThenInclude(c => c.ShoppingCartItems)
                .ThenInclude(i => i.Product)
                .FirstOrDefault(u => u.Id == orderDTO.UserId);

            var order = _mapper.Map<Order>(orderDTO);

            List<OrderDetail> details = new List<OrderDetail>();

            foreach (var item in user.ShoppingCart.ShoppingCartItems)
            {
                details.Add(new OrderDetail
                { 
                    Id = Guid.NewGuid(),
                    Amount = item.Amount,
                    OrderId = order.Id,
                    Price = item.Amount * item.Product.Price,
                    ProductId = item.Product.Id
                });
            }
            order.OrderDetails = details;
            _unitOfWork.Orders.Add(order);
            _unitOfWork.Commit();
        }

        public void DeleteOrder(Guid Id)
        {

        }

        public OrderDto GetOrder(Guid Id)
        {
            Order order = _unitOfWork.Orders.GetAll()
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                .FirstOrDefault(p => p.Id == Id);

            if (order == null)
                return null;

            return _mapper.Map<OrderDto>(order);
        }

        public void UpdateOrder(OrderDto order)
        {

        }
    }
}
