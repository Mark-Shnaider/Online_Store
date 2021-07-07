using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Entities.Base;

namespace Common.Models.Entities
{
    public class ShoppingCartItem:BaseEntity<Guid>
    {
        public int Amount { get; set; }
        public Guid ShoppingCartId { get; set; }
        public Guid ProductId { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual Product Product { get; set; }
    }
}
