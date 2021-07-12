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

            OrderViewModel orderVM = new OrderViewModel
            {
                Id = Guid.NewGuid(),
                UserId = cart.UserId,
                Items = _mapper.Map<List<ShoppingCartItemViewModel>>(cart.ShoppingCartItems)
            };

            return View(orderVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Order(OrderViewModel orderVM)
        {
            var orderDTO = _mapper.Map<OrderDto>(orderVM);
            _serviceProvider.GetRequiredService<IOrderService>().CreateOrder(orderDTO);
            return RedirectToAction("Orders", "User", new {UserId = orderVM.UserId });
        }

    }
}
