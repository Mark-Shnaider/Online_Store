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
    public class ProductService:BaseService, IProductService
    {
        public ProductService(IMapper mapper, IServiceProvider serviceProvider, IUnitOfWork unitOfWork)
            :base(mapper, serviceProvider, unitOfWork)
        {
            
        }
        public void CreateProduct(ProductDto productDto)
        {
            if (productDto == null)
            {
                return;
            }

            productDto.Id = Guid.NewGuid();
            Product product = _mapper.Map<Product>(productDto);
            _unitOfWork.Products.Add(product);
            _unitOfWork.Commit();
        }

        public void DeleteProduct(ProductDto productDTO)
        {
            if (productDTO == null)
            {
                return;
            }

            Product product = _mapper.Map<Product>(productDTO);
            _unitOfWork.Products.Delete(product.Id);
            _unitOfWork.Commit();
        }

        public List<AmountDto> GetAmounts(Guid Id)
        {
            List<Amount> amounts = _unitOfWork.Products.GetAll()
                .Include(p => p.Amounts).
                FirstOrDefault(p => p.Id == Id).
                Amounts.ToList();
            if (amounts == null)
                return null;
            return _mapper.Map<List<AmountDto>>(amounts);
        }

        public ProductDto GetProduct(Guid Id)
        {
            Product product = _unitOfWork.Products.GetAll()
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == Id);

            if (product == null) 
                return null;
            
            return _mapper.Map<ProductDto>(product);
        }

        public void UpdateProduct(ProductDto productDTO)
        {
            if (productDTO == null)
                return;

            Product product = _mapper.Map<Product>(productDTO);
            _unitOfWork.Products.AddOrUpdate(product);
            _unitOfWork.Commit();
        }

        public List<ProductDto> GetProducts()
        {
            var productsDTO = _unitOfWork.Products.GetAll()
                .OrderBy(p => p.Name)
                .ToList();
            var products = _mapper.Map<List<ProductDto>>(productsDTO);
            return products;
        }
      
    }
}
