using System;
using System.Collections.Generic;
using Common.Contracts.Services.Base;
using Common.Models.DTO;

namespace Common.Contracts.Services
{
    public interface IOrderService :IService
    {
        public void CreateOrder(OrderDto order);
        public OrderDto GetOrder(Guid OrderId);
        public List<OrderDto> GetOrders(Guid UserId);
        public void UpdateOrder(OrderDto order);
        public void DeleteOrder(Guid Id);
    }
}
