using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Online_Store.Models.Base;
using Online_Store.Models;
using System.ComponentModel.DataAnnotations;

namespace Online_Store.Areas.Admin.Models
{
    public class ChangeRoleViewModel:BaseEntityViewModel<Guid>
    {
        public string UserEmail { get; set; }
        public List<IdentityRole<Guid>> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }
        public ChangeRoleViewModel()
        {
            AllRoles = new List<IdentityRole<Guid>>();
            UserRoles = new List<string>();
        }
    }
}
