using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Common.Models.Entities.Base;
using Common.Contracts.Base;

namespace Common.Models.Entities.Identity
{
    public class UserRole:IdentityRole<Guid>
    {
        public UserRole(string name)
            :base(name)
        { 
        }
    }
}
