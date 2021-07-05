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

        public IActionResult Add(int id, int? amount = 1, string returnUrl = null)
        {
            //var food = _foodService.GetById(id);
            //returnUrl = returnUrl.Replace("%2F", "/");
            //bool isValidAmount = false;
            //if (food != null)
            //{
            //    isValidAmount = _shoppingCart.AddToCart(food, amount.Value);
            //}

            //return Index(isValidAmount, returnUrl);
            return View();
        }
    }
}
