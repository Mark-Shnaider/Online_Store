using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Common.Models.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Common.Models.DTO;
using Common.Contracts.Services;
using Common.Contracts.Services.Identity;
using Logic.Services;
using Online_Store.Areas.Products.Models;
using Online_Store.Base;
using Online_Store.Areas.Identity.Models;


namespace Online_Store.Areas.Admin.Controllers
{
    public class ProductController:BaseController
    {
        public ProductController(IMapper mapper, IServiceProvider serviceProvider)
            : base(mapper, serviceProvider)
        {
           
        }
        public IActionResult IndexProducts()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DetailsProducts(Guid id)
        {
            ProductDto product = _serviceProvider.GetRequiredService<IProductService>().GetProduct(id);
            ProductViewModel productVM = _mapper.Map<ProductViewModel>(product);

            return View(productVM);
        }
        [HttpGet]
        public IActionResult Create(ProductViewModel product)
        {
            ProductDto productDto = _mapper.Map<ProductDto>(product);
            _serviceProvider.GetRequiredService<IProductService>().CreateProduct(productDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            ProductDto productDTO = _serviceProvider.GetRequiredService<IProductService>().GetProduct(Id);
            ProductViewModel productVM = _mapper.Map<ProductViewModel>(productDTO);

            return View(productVM);
        }

        public IActionResult Delete(Guid Id)
        {
            ProductDto productDTO = _serviceProvider.GetRequiredService<IProductService>().GetProduct(Id);
            ProductViewModel productVM = _mapper.Map<ProductViewModel>(productDTO);

            return View(productVM);
        }

    }
}
