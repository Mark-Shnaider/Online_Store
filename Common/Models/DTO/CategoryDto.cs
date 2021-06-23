using System;
using Common.Models.DTO.Base;

namespace Common.Models.DTO
{
    public class CategoryDto :BaseDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
