using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.DTO.Base;

namespace Common.Models.DTO
{
    public class AmountDto:BaseDto<Guid>
    {
        public int Qunatity { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public OrderDto Order { get; set; }
        public ProductDto Product { get; set; }
    }
}
