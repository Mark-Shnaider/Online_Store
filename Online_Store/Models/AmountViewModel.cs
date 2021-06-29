using System;
using Online_Store.Areas.Products.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Store.Models
{
    public class AmountViewModel
    {
        public int Qunatity { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public OrderViewModel Order { get; set; }
        //public ProductViewModel Product { get; set; }
    }
}
