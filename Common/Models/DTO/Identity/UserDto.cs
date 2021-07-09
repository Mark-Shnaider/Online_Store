using System;
using System.Collections.Generic;
using Common.Models.DTO.Base;


namespace Common.Models.DTO.Identity
{
    public class UserDto:BaseDto<Guid>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<OrderDto> Orders { get; set; }
        public ShoppingCartDto ShoppingCart { get; set; }
    }
}
