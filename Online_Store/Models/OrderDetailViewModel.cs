using System;
using Online_Store.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_Store.Models.Base;

namespace Online_Store.Models
{
    public class OrderDetailViewModel:BaseEntityViewModel<Guid>
    {
        public int Amount { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
    }
}
