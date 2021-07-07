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
        public IActionResult Index(Guid Id, string categoryName = null)
        {
            var productsDTO = _serviceProvider
                .GetRequiredService<IProductService>()
                .GetProductsByCategory(categoryName);

            var productsVM = _mapper.Map<List<ProductCustomerViewModel>>(productsDTO);

            _serviceProvider.GetRequiredService<IShoppingCartService>().CreateCart(default);
            var cartDTO = _serviceProvider.GetRequiredService<IShoppingCartService>().GetCartByUser(Id);

            var cartVM = _mapper.Map<ShoppingCartViewModel>(cartDTO);
            cartVM.Products = productsVM;
            return View(cartVM);
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
