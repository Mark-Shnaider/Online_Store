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
    public class UserController:BaseController
    {
        public UserController(IMapper mapper, IServiceProvider serviceProvider)
            : base(mapper, serviceProvider)
        {
        }

        public IActionResult Orders(Guid UserId)
        {
            List<OrderDto> ordersDTO = _serviceProvider.GetRequiredService<IOrderService>().GetOrders(UserId);

            var ordersVM = _mapper.Map<List<OrderViewModel>>(ordersDTO);
            return View(ordersVM);
        }
    }
}
