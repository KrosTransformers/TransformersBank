using System;

namespace Transformers.Bank.Entities
{
    public interface IEntity<T>
    {
        T Id { get; set; }
        DateTimeOffset CreatedAt { get; set; }
        DateTimeOffset? ChangedAt { get; set; }
    }
}
