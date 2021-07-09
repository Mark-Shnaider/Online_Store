using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Common.Models.DTO;
using Common.Contracts.Services;
using Logic.Services;
using Online_Store.Models;
using Online_Store.Controllers.Base;

namespace Online_Store.Controllers
{
    public class OrderController:BaseController
    {
        public OrderController(IMapper mapper, IServiceProvider serviceProvider)
            : base(mapper, serviceProvider)
        {
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Order(Guid CartId)
        {
            var cart = _serviceProvider.GetRequiredService<IShoppingCartService>().GetCart(CartId);

            List<OrderDetailViewModel> details = new List<OrderDetailViewModel>();
            OrderViewModel orderVM = new OrderViewModel { UserId = cart.UserId, Id = Guid.NewGuid()  };
            foreach (var item in cart.ShoppingCartItems)
            {
                details.Add(new OrderDetailViewModel 
                {
                    Id = Guid.NewGuid(),
                    OrderId = orderVM.Id,
                    Amount = item.Amount, 
                    ProductId = item.Product.Id,
                    Price = item.Amount * item.Product.Price
                });
            }
            orderVM.OrderDetails = details;

            return View(orderVM);
        }

        [HttpPost]
        public void Order(OrderViewModel orderVM)
        { 
            
        }

    }
}
