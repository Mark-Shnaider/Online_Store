using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Services.Base;
using Common.Models.DTO;
using Common.Models.Entities;
using AutoMapper;
using Common.Contracts;
using Common.Contracts.Services;

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
            _unitOfWork.Products.Delete(product);
        }

        public List<AmountDto> GetAmounts(Guid Id)
        {
            throw new NotImplementedException();
        }

        public ProductDto GetProduct(Guid Id)
        {
            Product product = _unitOfWork.Products.GetById(Id);
            if (product == null) 
                return null;
            ProductDto productdto = _mapper.Map<ProductDto>(product);
            return productdto;
        }

        public void UpdateProduct(ProductDto productDTO)
        {
            if (productDTO == null)
            {
                return;
            }

            Product product = _mapper.Map<Product>(productDTO);
            _unitOfWork.Products.AddOrUpdate(product);
        }
    }
}
