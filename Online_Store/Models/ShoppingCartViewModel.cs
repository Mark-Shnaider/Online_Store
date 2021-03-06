using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Online_Store.Models.Base;

namespace Online_Store.Models
{
    public class ShoppingCartViewModel : BaseEntityViewModel<Guid>
    {
        public List<ShoppingCartItemViewModel> ShoppingCartItems { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public List<CategoryIndexViewModel> Categories { get; set; }
    }
}
