using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_Store.Models.Base;
using Online_Store.Models;

namespace Online_Store.Areas.Products.Models
{
    public class ProductViewModel:BaseEntityViewModel<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public CategoryViewModel Category { get; set; }
        public List<AmountViewModel> Amounts { get; set; }
    }
}
