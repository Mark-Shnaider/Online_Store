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
    public class ProductController:BaseController
    {
        public ProductController(IMapper mapper, IServiceProvider serviceProvider)
            : base(mapper, serviceProvider)
        {
        }
        public IActionResult Index()
        {
            var productsDTO = _serviceProvider.GetRequiredService<IProductService>().GetProducts();

            var productsVM = _mapper.Map<List<ProductCustomerViewModel>>(productsDTO);
            return View(productsVM);
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
