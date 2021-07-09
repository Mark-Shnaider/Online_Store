using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.DTO
{
    public class OrderDetailDto
    {
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public  OrderDto Order { get; set; }
        public  ProductDto Product { get; set; }
    }
}
