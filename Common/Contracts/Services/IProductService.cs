using System;
using System.Collections.Generic;
using Common.Contracts.Services.Base;
using Common.Models.DTO;

namespace Common.Contracts.Services
{
    public interface IProductService :IService
    {
        public void CreateProduct(ProductDto product);
        public ProductDto GetProduct(Guid Id);
        public void UpdateProduct(ProductDto product);
        public void DeleteProduct(ProductDto product);
        public List<ProductDto> GetProducts();
        public List<ProductDto> GetProductsByCategory(string name);
        public List<AmountDto> GetAmounts(Guid Id);
        public bool IsValidName(string Name);
    }
}
