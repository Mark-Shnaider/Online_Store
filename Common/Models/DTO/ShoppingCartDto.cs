using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.DTO.Base;

namespace Common.Models.DTO
{
    public class ShoppingCartDto:BaseDto<Guid>
    {
        public List<ShoppingCartItemDto> ShoppingCartItems { get; set; }
    }
}
