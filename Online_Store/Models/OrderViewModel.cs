using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_Store.Models.Base;
using Common.Helpers.Enum;
using Online_Store.Models;

namespace Online_Store.Models
{
    public class OrderViewModel : BaseEntityViewModel<Guid>
    {
        public decimal Price { get; set; }
        public string Commentary { get; set; }
        public Status Status { get; set; }
        public Guid UserId { get; set; }
        public List<ShoppingCartItemViewModel> OrderDetails { get; set; }
    }
}
