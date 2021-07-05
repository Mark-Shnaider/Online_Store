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
    public class ShoppingCartController:BaseController
    {
        public ShoppingCartController(IMapper mapper, IServiceProvider serviceProvider)
            : base(mapper, serviceProvider)
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Guid Id, int amount = 1, string returnUrl = null)
        {
            var product = _serviceProvider.GetRequiredService<IProductService>().GetProduct(Id);
            //returnUrl = returnUrl.Replace("%2F", "/");
            var item = new ShoppingCartItemDto { Product = product};
            bool isValidAmount = false;
            if (product != null)
            {
                isValidAmount = _serviceProvider.GetRequiredService<IShoppingCartService>().AddToCart(item);
            }

            //return Index(isValidAmount, returnUrl);
            return View();
        }
    }
}
