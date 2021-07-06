using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Entities.Base;

namespace Common.Models.Entities
{
    public class ShoppingCart:BaseEntity<Guid>
    {
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        public Guid UserId { get; set; }
    }
}
