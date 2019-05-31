using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformers.Bank.Entities
{
    public interface IEntity<T>
    {
        T Id { get; set; }
        DateTimeOffset CreatedAt { get; set; }
        DateTimeOffset? ChangedAt { get; set; }
    }
}
