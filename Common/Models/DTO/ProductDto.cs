using System;
using System.Collections.Generic;
using Common.Models.DTO.Base;

namespace Common.Models.DTO
{
    public class ProductDto :BaseDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public ShoppingCartItemDto ShoppingCartItem { get; set; }
    }
}
