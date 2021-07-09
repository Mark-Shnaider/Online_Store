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
        public void CreateOrder(Guid CartId)
        {
            

            //_unitOfWork.Orders.Add();
            _unitOfWork.Commit();
        }

        public void DeleteOrder(OrderDto order)
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
