using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Entities.Base;
using Common.Models.Entities.Identity;
using Common.Helpers.Enum;

namespace Common.Models.Entities
{
    public class OrderDetail : BaseEntity<Guid>
    {
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        //Nav properties
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
