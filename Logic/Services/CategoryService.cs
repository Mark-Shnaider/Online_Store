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
        public void CreateCategory(CategoryDto categoryDTO)
        {
            if (categoryDTO == null)
            {
                return;
            }

            categoryDTO.Id = Guid.NewGuid();
            Category category = _mapper.Map<Category>(categoryDTO);
            _unitOfWork.Categories.Add(category);
            _unitOfWork.Commit();
        }
        public List<CategoryDto> GetCategories()
        {
            var categories = _unitOfWork.Categories.GetAll()
                .OrderBy(c => c.Name)
                .ToList();
            var result = _mapper.Map<List<CategoryDto>>(categories);
            return result;
        }
        public CategoryDto GetCategory(Guid Id)
        {
            Category category = _unitOfWork.Categories.GetAll()
                .FirstOrDefault(c => c.Id == Id);

            if (category == null)
                return null;

            return _mapper.Map<CategoryDto>(category);
        }
        public void UpdateCategory(CategoryDto categoryDTO)
        {
            if (categoryDTO == null)
                return;

            Category category = _mapper.Map<Category>(categoryDTO);
            _unitOfWork.Categories.AddOrUpdate(category);
            _unitOfWork.Commit();
        }
        public void DeleteCategory(CategoryDto categoryDTO)
        {
            if (categoryDTO == null)
            {
                return;
            }

            Category category = _mapper.Map<Category>(categoryDTO);
            _unitOfWork.Categories.Delete(category.Id);
            _unitOfWork.Commit();
        }
    }
}
