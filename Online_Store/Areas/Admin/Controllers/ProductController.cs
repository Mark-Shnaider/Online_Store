﻿using System.Threading.Tasks;
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
using Online_Store.Areas.Admin.Models;
using Online_Store.Base;
using Online_Store.Areas.Identity.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Online_Store.Models;

namespace Online_Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController:BaseController
    {
        public ProductController(IMapper mapper, IServiceProvider serviceProvider)
            : base(mapper, serviceProvider)
        {
           
        }
        public IActionResult Index()
        {
            var productsDTO = _serviceProvider.GetRequiredService<IProductService>().GetProducts();

            var productsVM = _mapper.Map<List<ProductViewModel>>(productsDTO);
            return View(productsVM);
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            ProductDto product = _serviceProvider.GetRequiredService<IProductService>().GetProduct(id);
            ProductViewModel productVM = _mapper.Map<ProductViewModel>(product);

            return View(productVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categoriesDTO = _serviceProvider.GetRequiredService<ICategoryService>().GetCategories();
            var categoriesVM = _mapper.Map<List<CategoryViewModel>>(categoriesDTO);
            ProductViewModel product = new ProductViewModel {Categories = categoriesVM};
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel productVM)
        {
            ProductDto productDTO = _mapper.Map<ProductDto>(productVM);

            _serviceProvider.GetRequiredService<IProductService>().CreateProduct(productDTO);
            return RedirectToAction("Index", "Product", new { area ="Admin"});
        }

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            var categoriesDTO = _serviceProvider.GetRequiredService<ICategoryService>().GetCategories();
            var categoriesVM = _mapper.Map<List<CategoryViewModel>>(categoriesDTO);

            ProductDto productDTO = _serviceProvider.GetRequiredService<IProductService>().GetProduct(Id);
            ProductViewModel productVM = _mapper.Map<ProductViewModel>(productDTO);

            productVM.Categories = categoriesVM;
            return View(productVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel productVM)
        {
            ProductDto productDTO = _mapper.Map<ProductDto>(productVM);

            _serviceProvider.GetRequiredService<IProductService>().UpdateProduct(productDTO);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
        [HttpGet]
        public IActionResult Delete(Guid Id)
        {
            ProductDto productDTO = _serviceProvider.GetRequiredService<IProductService>().GetProduct(Id);
            ProductViewModel productVM = _mapper.Map<ProductViewModel>(productDTO);

            return View(productVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid Id)
        {
            ProductDto product = _serviceProvider.GetRequiredService<IProductService>().GetProduct(Id);
            _serviceProvider.GetRequiredService<IProductService>().DeleteProduct(product);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

    }
}
