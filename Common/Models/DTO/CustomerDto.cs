using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.DTO.Base;

namespace Common.Models.DTO
{
    public class CustomerDto :BaseDto<Guid>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public List<OrderDto> Orders { get; set; }
    }
}
