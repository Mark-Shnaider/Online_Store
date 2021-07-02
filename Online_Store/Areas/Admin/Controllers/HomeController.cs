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
    public class HomeController:Controller
    {

        public IActionResult StartAdminPage()
        {
            return View();
        }
    }
}
