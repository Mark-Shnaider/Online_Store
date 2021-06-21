using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Online_Store.Controllers.Base
{
    public class BaseController : Controller
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly IMapper _mapper;

        public BaseController(IMapper mapper, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new NullReferenceException("ServiceProvider exception");
            _mapper = mapper ?? throw new NullReferenceException("Mapper exception");
        }
    }
}
