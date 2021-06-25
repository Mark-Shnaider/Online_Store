﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_Store.Models.Base;

namespace Online_Store.Models
{
    public class CategoryViewModel:BaseEntityViewModel<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}