﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_Store.Models.Base;
using Online_Store.Models;
using System.ComponentModel.DataAnnotations;

namespace Online_Store.Areas.Admin.Models
{
    public class CategoryViewModel : BaseEntityViewModel<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}