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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel userVM)
        {
            User user = new User { Id = Guid.NewGuid(), UserName= userVM.UserName, Email = userVM.Email};
            //User user = _mapper.Map<User>(userVM);
            //if (user == null)
            //    return BadRequest();
            //user.Id = Guid.NewGuid();

            //Добавить modelstateisvalid
            var result = await _userManager.CreateAsync(user, userVM.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                await _userManager.AddToRoleAsync(user, "User");
                return RedirectToAction("Index", "Product", new { area ="Products"});
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

        [HttpGet]
        public IActionResult Authorize(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Authorize(LoginViewModel loginVM)
        {
            User user = await _userManager.FindByNameAsync(loginVM.UserName);
            //Add ModelState и rememberMe
            if (user == null)
                return BadRequest();
            var result = await _signInManager.PasswordSignInAsync(user.UserName, loginVM.Password, loginVM.RememberMe, false);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(loginVM.ReturnUrl) && Url.IsLocalUrl(loginVM.ReturnUrl))
                {
                    return Redirect(loginVM.ReturnUrl);
                }
                else
                {
                    if (user.UserName == "Admin")
                        return RedirectToAction("StartAdminPage", "Home", new { area = "Admin" });
                    return RedirectToAction("Index", "Product", new { area="Products"});
                }
            }
            else
            {
                ModelState.AddModelError("", "Wrong password or login.");
            }
            return View(loginVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Product", new { area = "Products"});
        }

    }
}
