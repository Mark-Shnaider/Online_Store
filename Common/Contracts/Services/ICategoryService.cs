using System;
using System.Collections.Generic;
using Common.Contracts.Services.Base;
using Common.Models.DTO;

namespace Common.Contracts.Services
{
    public interface ICategoryService:IService
    {
        public void CreateCategory(CategoryDto category);
        public CategoryDto GetCategory(Guid Id);
        public void UpdateCategory(CategoryDto category);
        public void DeleteCategory(CategoryDto category);
        public List<CategoryDto> GetCategories();
        public bool IsValidName(string Name); 
    }
}
