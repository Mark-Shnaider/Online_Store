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
                .Where(x => x.ShoppingCartId == CartId)
                .ToList();

            return _mapper.Map<List<ShoppingCartItemDto>>(items);
        }
    }
}
