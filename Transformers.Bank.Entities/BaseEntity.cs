using System;

namespace Transformers.Bank.Entities
{
    public class BaseEntity<T> : IEntity<T>
    {
        public T Id { get ; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? ChangedAt { get; set; }
    }
}
