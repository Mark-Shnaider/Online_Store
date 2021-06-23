using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace Common.Models.Entities.Identity
{
    public class User : IdentityUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
