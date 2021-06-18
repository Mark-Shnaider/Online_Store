using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.DTO.Base;

namespace Common.Models.DTO
{
    class CategoryDto:BaseDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
