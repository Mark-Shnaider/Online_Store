using System;
using System.Collections.Generic;
using Common.Helpers.Enum;
using Common.Models.DTO.Base;
using Common.Models.DTO.Identity;

namespace Common.Models.DTO
{
    public class OrderDto : BaseDto<Guid>
    {
        public decimal Price { get; set; }
        public string Commentary { get; set; }
        public Status Status { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public UserDto User { get; set; }
        public ProductDto Product { get; set; }
    }
}
