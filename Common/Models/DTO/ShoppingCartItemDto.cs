using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.DTO.Base;

namespace Common.Models.DTO
{
    public class ShoppingCartItemDto:BaseDto<Guid>
    {
        public ProductDto Product { get; set; }
        public int Amount { get; set; }
        public ShoppingCartDto ShoppingCart { get; set; }
        public Guid ShoppingCartId { get; set; }
    }
}
