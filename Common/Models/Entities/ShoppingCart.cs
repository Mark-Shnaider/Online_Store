using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Entities.Base;
using Common.Models.Entities.Identity;

namespace Common.Models.Entities
{
    public class ShoppingCart:BaseEntity<Guid>
    {
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
    }
}
