using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Common.Models.Entities.Identity;
using Common.Models.DTO;
using Common.Contracts.Services;
using Common.Contracts.Services.Identity;
using Logic.Services;
using Online_Store.Areas.Admin.Models;
using Online_Store.Controllers.Base;
using Online_Store.Areas.Identity.Models;
using Online_Store.Models;


namespace Online_Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController:BaseController
    {
        public CategoryController(IMapper mapper, IServiceProvider serviceProvider)
            : base(mapper, serviceProvider)
        {

        }

        public IActionResult Index()
        {
            var categoriesDTO = _serviceProvider.GetRequiredService<ICategoryService>().GetCategories();

            var categoriesVM = _mapper.Map<List<CategoryViewModel>>(categoriesDTO);
            return View(categoriesVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryViewModel categoryVM)
        {
            CategoryDto categoryDTO = _mapper.Map<CategoryDto>(categoryVM);

            _serviceProvider.GetRequiredService<ICategoryService>().CreateCategory(categoryDTO);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            CategoryDto categoryDTO = _serviceProvider.GetRequiredService<ICategoryService>().GetCategory(Id);
            CategoryViewModel categoryVM = _mapper.Map<CategoryViewModel>(categoryDTO);

            return View(categoryVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryViewModel categoryVM)
        {
            CategoryDto categoryDTO = _mapper.Map<CategoryDto>(categoryVM);

            _serviceProvider.GetRequiredService<ICategoryService>().UpdateCategory(categoryDTO);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }
        [HttpGet]
        public IActionResult Delete(Guid Id)
        {
            CategoryDto categoryDTO = _serviceProvider.GetRequiredService<ICategoryService>().GetCategory(Id);
            CategoryViewModel categoryVM = _mapper.Map<CategoryViewModel>(categoryDTO);

            return View(categoryVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid Id)
        {
            CategoryDto category = _serviceProvider.GetRequiredService<ICategoryService>().GetCategory(Id);
            _serviceProvider.GetRequiredService<ICategoryService>().DeleteCategory(category);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyName(string Name)
        {
            if (!_serviceProvider.GetRequiredService<ICategoryService>().IsValidName(Name))
            {
                return Json($"Name {Name} is already in use.");
            }

            return Json(true);
        }
    }
}
