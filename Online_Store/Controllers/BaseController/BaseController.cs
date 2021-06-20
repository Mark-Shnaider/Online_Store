using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Online_Store.Controllers.Base
{
    public class BaseController : Controller
    {
        protected readonly IServiceProvider _serviceHost;
        protected readonly IMapper _mapper;

        public BaseController(IMapper mapper, IServiceProvider serviceHost)
        {
            _serviceHost = serviceHost ?? throw new NullReferenceException("ServiceProvider's exception");
            _mapper = mapper ?? throw new NullReferenceException("Mapper's exception");
        }
    }
}
