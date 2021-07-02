using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Online_Store.Models.Base;

namespace Online_Store.Models
{
    public class ProductCustomerViewModel : BaseEntityViewModel<Guid>
    {
        [Display(Name = "Название продукта")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
        [Display(Name = "Количество")]
        public int Quantity { get; set; }
        [Display(Name = "Категория")]
        public string CategoryName { get; set; }
    }
}
