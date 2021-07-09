using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Common.Models.DTO;
using Common.Models.Entities;
using Common.Contracts;
using Common.Contracts.Services;
using Logic.Services.Base;

using System.Threading.Tasks;

namespace Logic.Services
{
    public class ShoppingCartItemService:BaseService, IShoppingCartItemService
    {
        public ShoppingCartItemService(IMapper mapper, IServiceProvider serviceProvider, IUnitOfWork unitOfWork)
            : base(mapper, serviceProvider, unitOfWork)
        {

        }

        public List<ShoppingCartItemDto> GetItems(Guid CartId)
        {
            var items = _unitOfWork.ShoppingCartItems
                .GetAll()
                .Include(i => i.Product)
                .Where(x => x.ShoppingCartId == CartId)
                .ToList();

            return _mapper.Map<List<ShoppingCartItemDto>>(items);
        }

        public void DeleteItem(Guid ItemId)
        {
            var item = _unitOfWork.ShoppingCartItems
                .GetAll()
                .AsNoTracking()
                .Include(i => i.Product)
                .FirstOrDefault(i => i.Id == ItemId);

            if (item == null)
                return;
            item.Product.Quantity += item.Amount;
            _unitOfWork.Products.AddOrUpdate(item.Product);

            _unitOfWork.ShoppingCartItems.Delete(item);
            _unitOfWork.Commit();
            return;
        }
    }
}
