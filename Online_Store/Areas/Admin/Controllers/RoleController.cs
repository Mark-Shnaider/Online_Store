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
using Online_Store.Areas.Identity.Models;
using Online_Store.Models;
using Online_Store.Controllers.Base;

namespace Online_Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RoleController:BaseController
    {
        RoleManager<IdentityRole<Guid>> _roleManager;
        UserManager<User> _userManager;
        public RoleController(IMapper mapper, IServiceProvider serviceProvider, RoleManager<IdentityRole<Guid>> roleManager, UserManager<User> userManager)
            : base(mapper, serviceProvider)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        { 
            return View(_roleManager.Roles.ToList());
        }

        public IActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole<Guid>(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(name);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole<Guid> role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }

        public IActionResult UserList() => View(_userManager.Users.ToList());

        public async Task<IActionResult> Edit(string userId)
        {
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    Id = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("UserList");
            }

            return NotFound();
        }
    }
}
