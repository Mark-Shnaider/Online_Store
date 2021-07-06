﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Entities.Base;

namespace Common.Models.Entities
{
    public class ShoppingCartItem:BaseEntity<Guid>
    {
        public Product Product { get; set; }
        public int Amount { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public Guid ShoppingCartId { get; set; }
    }
}