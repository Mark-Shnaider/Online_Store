using System;
using Online_Store.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_Store.Models.Base;

namespace Online_Store.Models
{
    public class AmountViewModel : BaseEntityViewModel<Guid>
    {
        public int Qunatity { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public OrderViewModel Order { get; set; }
        //public ProductViewModel Product { get; set; }
    }
}
