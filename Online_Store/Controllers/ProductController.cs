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
using Common.Models.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Common.Contracts.Services.Identity;
using Online_Store.Areas.Identity.Models;

namespace Online_Store.Controllers
{
    public class ProductController:BaseController
    {
        public ProductController(IMapper mapper, IServiceProvider serviceProvider)
            : base(mapper, serviceProvider)
        {
        }
        public IActionResult Index(Guid Id, Guid CategoryId )
        {
            var cartDTO = _serviceProvider.GetRequiredService<IShoppingCartService>().GetCartByUser(Id);

            var cartVM = _mapper.Map<ShoppingCartViewModel>(cartDTO);

            var categoriesDTO = _serviceProvider.GetRequiredService<ICategoryService>().GetCategories();

            cartVM.Categories = _mapper.Map<List<CategoryIndexViewModel>>(categoriesDTO);
            cartVM.CategoryId = cartVM.Categories[0].Id;
            return View(cartVM);
        }


        public PartialViewResult GetProducts(CartTableViewModel cart)
        {
            var productsDTO = _serviceProvider
                .GetRequiredService<IProductService>()
                .GetProductsByCategory(cart.CategoryId);

            cart.Products = _mapper.Map<List<ProductCustomerViewModel>>(productsDTO);

            return PartialView("Partials/_CategorySelectPartial", cart);
        }

        public PartialViewResult GetCartItems(ShoppingCartViewModel cart)
        {
            var items = _serviceProvider.GetRequiredService<IShoppingCartItemService>().GetItems(cart.Id);
            cart.ShoppingCartItems = _mapper.Map<List<ShoppingCartItemViewModel>>(items);
            return PartialView("Partials/_CartPartial", cart);
        }


        [HttpGet]
        public IActionResult Details(Guid id)
        {
            ProductDto product = _serviceProvider.GetRequiredService<IProductService>().GetProduct(id);
            ProductCustomerViewModel productVM = _mapper.Map<ProductCustomerViewModel>(product);

            return View(productVM);
        }
    }
}
