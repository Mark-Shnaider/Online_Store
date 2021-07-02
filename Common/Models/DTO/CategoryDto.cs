using System;
using System.Collections.Generic;
using Common.Models.DTO.Base;

namespace Common.Models.DTO
{
    public class CategoryDto :BaseDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
