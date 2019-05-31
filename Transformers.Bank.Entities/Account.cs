using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformers.Bank.Entities
{
    public class Account: BaseEntity<long>
    {
        public string Name { get; set; }
        public string Iban { get; set; }
        public string Bic { get; set; }
        public string Currency { get; set; }
        public decimal OverdraftLimit { get; set; }
        public decimal Balance { get; set; }
        public decimal Reservations { get; set; }
        public DateTime Opened { get; set; }
        public DateTime? Closed { get; set; }

        public long BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        public virtual ICollection<Customer> Owners { get; set; } = new HashSet<Customer>();
        public virtual ICollection<Customer> Disponents { get; set; } = new HashSet<Customer>();
        public virtual ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
    }
}
