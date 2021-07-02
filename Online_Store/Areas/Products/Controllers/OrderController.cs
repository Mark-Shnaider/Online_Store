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
using Online_Store.Areas.Products.Models;
using Online_Store.Controllers.Base;

namespace Online_Store.Areas.Products.Controllers
{
    [Area("Products")]
    public class OrderController:BaseController
    {
        public OrderController(IMapper mapper, IServiceProvider serviceProvider)
            : base(mapper, serviceProvider)
        {
        }


    }
}
