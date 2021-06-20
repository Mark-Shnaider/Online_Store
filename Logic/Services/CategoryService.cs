using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers.Enum;
using Logic.Services.Base;
using Common.Contracts.Services;
using AutoMapper;
using Common.Contracts;
using Common.Models.DTO;
using Common.Models.Entities;

namespace Logic.Services
{
    public class CategoryService: BaseService, ICategoryService
    {
        public CategoryService(IMapper mapper, IServiceProvider serviceProvider, IUnitOfWork unitOfWork)
            : base(mapper, serviceProvider, unitOfWork)
        { 
        
        }
    }
}
