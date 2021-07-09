using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Online_Store.Models.Base;

namespace Online_Store.Models
{
    public class ShoppingCartItemViewModel:BaseEntityViewModel<Guid>
    {
        public ProductCustomerViewModel  Product { get; set; }
        public int Amount { get; set; }
        public Guid ShoppingCartId { get; set; }
        public decimal SubTotal { get => Product.Price * Amount; }
    }
}
