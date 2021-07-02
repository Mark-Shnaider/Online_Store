using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_Store.Models.Base;
using Online_Store.Models;

namespace Online_Store.Models
{
    public class CustomerViewModel : BaseEntityViewModel<Guid>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public List<OrderViewModel> Orders { get; set; }
    }
}
