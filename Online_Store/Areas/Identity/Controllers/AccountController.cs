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
using Logic.Services;
using Online_Store.Areas.Products.Models;
using Online_Store.Base;
using Online_Store.Areas.Identity.Models;

namespace Online_Store.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IMapper mapper, IServiceProvider serviceProvider, UserManager<User> userManager, SignInManager<User> signInManager)
            : base(mapper, serviceProvider)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel userVM)
        {
            User user = _mapper.Map<User>(userVM);
            if (user == null)
                return BadRequest();

            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                // установка куки
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Product");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }

    }
}