using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers.Enum;
using Common.Models.DTO.Base;

namespace Common.Models.DTO
{
    class OrderDto:BaseDto<Guid>
    {
        public decimal Price { get; set; }
        public string Commentary { get; set; }
        public Status Status { get; set; }
        public Guid CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
        public List<AmountDto> Amounts { get; set; }
    }
}
