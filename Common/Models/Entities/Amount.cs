using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Entities.Base;
using Common.Contracts.Base;

namespace Common.Models.Entities
{
    public class Amount:BaseEntity<Guid>
    {
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        //Navigation properties
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

    }
}
