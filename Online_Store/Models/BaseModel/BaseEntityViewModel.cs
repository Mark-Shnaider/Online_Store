using System;

namespace Online_Store.Models.Base
{
    public class BaseEntityViewModel<T>
        where T : IEquatable<T>
    {
        public T Id { get; set; }
    }
}
