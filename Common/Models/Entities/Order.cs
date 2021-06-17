using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Entities.Base;
using Common.Helpers.Enum;

namespace Common.Models.Entities
{
    public class Order:BaseEntity<Guid>
    {
        public decimal Price { get; set; }
        public string Commentary { get; set; }
        public Status Status { get; set; }
        public Guid CustomerId { get; set; }
        //Navigation properties
        public Customer Customer { get; set; }
        public ICollection<Amount> Amounts { get; set; }
    }
}
