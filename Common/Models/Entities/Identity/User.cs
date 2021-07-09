using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Common.Models.Entities.Base;
using Common.Contracts.Base;
using Common.Models.Entities;

namespace Common.Models.Entities.Identity
{
    public class User :IdentityUser<Guid>, IBaseEntity<Guid>
    { 
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
