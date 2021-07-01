using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_Store.Models.Base;
using Online_Store.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Online_Store.Areas.Admin.Models
{
    public class ProductViewModel : BaseEntityViewModel<Guid>
    {
        [Required]
        [Display(Name="Название продукта")]
        [StringLength(25)]
        [Remote(areaName: "Admin", controller: "Product", action:"VerifyName")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Описание")]
        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [Range(1, 100000)]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Количество")]
        [Range(1, 500)]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Принадлежность к категории")]
        public Guid CategoryId { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
    }
}
