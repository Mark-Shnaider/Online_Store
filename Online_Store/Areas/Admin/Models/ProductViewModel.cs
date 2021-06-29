using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_Store.Models.Base;
using Online_Store.Models;
using System.ComponentModel.DataAnnotations;

namespace Online_Store.Areas.Admin.Models
{
    public class ProductViewModel : BaseEntityViewModel<Guid>
    {
        [Display(Name="Название продукта")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
        [Display(Name = "Количество")]
        public int Quantity { get; set; }
        [Display(Name = "Принадлежность к категории")]
        public Guid CategoryId { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
    }
}
