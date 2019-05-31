using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformers.Bank.Entities
{
    public class BaseEntity<T> : IEntity<T>
    {
        public T Id { get ; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? ChangedAt { get; set; }
    }
}
