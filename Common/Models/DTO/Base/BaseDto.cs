using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.DTO.Base
{
    class BaseDto<T>
        where T: IEquatable<T>
    {
        public T Id { get; set; }
    }
}
