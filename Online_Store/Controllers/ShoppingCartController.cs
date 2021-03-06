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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Web;


namespace Online_Store.Controllers
{
    public class ShoppingCartController:BaseController
    {
        public ShoppingCartController(IMapper mapper, IServiceProvider serviceProvider)
            : base(mapper, serviceProvider)
        {

        }

        public IActionResult Index(Guid cartid)
        {
            var cartDTO = _serviceProvider.GetRequiredService<IShoppingCartService>().GetCart(cartid);

            if (cartDTO == null)
                return BadRequest();

            var cartVM = _mapper.Map<ShoppingCartViewModel>(cartDTO);

            return View(cartVM);
        }

        [HttpPost]
        public JsonResult Add(Guid CartId, Guid ProductId, int amount)
        {
            if (CartId == default)
                return Json(new
                {
                    Data = new
                    {
                        isValid = false
                    }
                });

            bool isValidAmount = false;

            var product = _serviceProvider.GetRequiredService<IProductService>().GetProduct(ProductId);

            if (product != null && amount <= product.Quantity)
            {
                var item = new ShoppingCartItemDto { Product = product, Id = Guid.NewGuid(), ShoppingCartId = CartId, Amount = amount };
                isValidAmount = _serviceProvider.GetRequiredService<IShoppingCartService>().AddToCart(item);
            }

            return Json(new
            {
                Data = new
                {
                    isValid = isValidAmount
                }
            });
        }

        [HttpPost]
        public JsonResult Remove(Guid ItemId)
        {
            _serviceProvider.GetRequiredService<IShoppingCartItemService>().DeleteItem(ItemId);
            return Json(new
            {
                Data = new
                {
                    //isValid = isValidAmount
                }
            });
        }
    }
}
