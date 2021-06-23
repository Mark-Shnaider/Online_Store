using System;
using System.Collections.Generic;
using Common.Contracts.Services.Base;
using Common.Models.DTO;

namespace Common.Contracts.Services
{
    public interface IOrderService :IService
    {
        public void CreateOrder(OrderDto order);
        public OrderDto GetOrder(Guid Id);
        public void UpdateOrder(OrderDto order);
        public void DeleteOrder(OrderDto order);
    }
}
