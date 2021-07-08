using System;
using Online_Store.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_Store.Models.Base;

namespace Online_Store.Models
{
    public class CartTableViewModel:BaseEntityViewModel<Guid>
    {
        public Guid CategoryId { get; set; }
        public List<ProductCustomerViewModel> Products { get; set; }
    }
}
