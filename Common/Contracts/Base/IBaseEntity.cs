using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Base
{
    public interface IBaseEntity<T>
         where T : IEquatable<T>
    {
        public T Id { get; set; }
    }
}
