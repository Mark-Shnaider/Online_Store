using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_Store.Controllers.Base;
using AutoMapper;

namespace Online_Store.Controllers
{
    public class ProductController : BaseController
    {
        ProductController(IMapper mapper, IServiceProvider serviceProvider)
            : base(mapper, serviceProvider)
        {

        }
    }
}
