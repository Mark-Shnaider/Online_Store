using System;
using Common.Contracts.Base;

namespace Common.Models.Entities.Base
{
    public class BaseEntity<T>:IBaseEntity<T>
       where T : IEquatable<T>
    {
        public T Id { get; set; }
    }
}
