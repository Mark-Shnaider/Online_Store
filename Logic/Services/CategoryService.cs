using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Common.Models.DTO;
using Common.Models.Entities;
using Common.Contracts;
using Common.Contracts.Services;
using Logic.Services.Base;


namespace Logic.Services
{
    public class CategoryService: BaseService, ICategoryService
    {
        public CategoryService(IMapper mapper, IServiceProvider serviceProvider, IUnitOfWork unitOfWork)
            : base(mapper, serviceProvider, unitOfWork)
        { 
        
        }

        public List<CategoryDto> GetCategories()
        {
            var categories = _unitOfWork.Categories.GetAll()
                .OrderBy(c => c.Name)
                .ToList();
            var result = _mapper.Map <List<CategoryDto>>(categories);
            return result;
        }
    }
}
