using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Online_Store.Models.Base;
using System.Globalization;

namespace Online_Store.Models
{
    public class ProductCustomerViewModel : BaseEntityViewModel<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; } = 1;
        public string Total { get => (Price * Amount).ToString(CultureInfo.InvariantCulture); }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<string> Categories { get; set; }
    }
}
