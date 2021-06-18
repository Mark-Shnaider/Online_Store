using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Entities.Base;
        
namespace Common.Models.Entities
{
    public class Category:BaseEntity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
