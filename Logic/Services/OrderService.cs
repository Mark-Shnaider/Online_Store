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

            if (user == null)
                return;

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

            _serviceProvider.GetRequiredService<IShoppingCartItemService>().DeleteItems(user.ShoppingCart.Id);
            return;
        }

        public void DeleteOrder(Guid Id)
        {
            Order order = _unitOfWork.Orders
                .GetAll()
                .FirstOrDefault(o => o.Id == Id);
            if (order == null)
                return;
            _unitOfWork.Orders.Delete(order);
            _unitOfWork.Commit();

            return;
        }

        public OrderDto GetOrder(Guid OrderId)
        {
            Order order = _unitOfWork.Orders.GetAll()
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                .FirstOrDefault(p => p.Id == OrderId);

            if (order == null)
                return null;

            return _mapper.Map<OrderDto>(order);
        }

        public List<OrderDto> GetOrders(Guid UserId)
        {
             List<Order> orders = _unitOfWork.Orders
                .GetAll()
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.Product)
                .Where(o => o.UserId == UserId)
                .ToList();

            if (orders == null)
                return null;

            List<OrderDto> ordersDTO = _mapper.Map<List<OrderDto>>(orders);
            return ordersDTO;
        }

        public void UpdateOrder(OrderDto order)
        {

        }
    }
}
