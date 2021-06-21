using AutoMapper;
using Common.Contracts;
using Common.Contracts.Services;
using System;

namespace Logic.Services.Base
{
    public class BaseService
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IServiceProvider _serviceProvider;
        protected readonly IMapper _mapper;

        public BaseService(IMapper mapper, IServiceProvider serviceProvider, IUnitOfWork unitOfWork)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException("ServiceProvider exception");
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException("UnitOfWork exception");
            _mapper = mapper ?? throw new ArgumentNullException("Automapper exception");
        }

    }
}
