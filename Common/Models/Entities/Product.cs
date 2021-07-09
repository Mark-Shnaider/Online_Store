 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Entities.Base;

namespace Common.Models.Entities
{
    public class Product : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
        //Navigation properties
        public virtual Category Category { get; set; }
        public virtual ShoppingCartItem ShoppingCartItem { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
