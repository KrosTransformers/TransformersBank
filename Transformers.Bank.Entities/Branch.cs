using System.Collections.Generic;

namespace Transformers.Bank.Entities
{
    public class Branch: BaseEntity<long>
    {
        public string BranchCode { get; set; }
        public string Name { get; set; }

        public long AddressId { get; set; }
        public virtual Address Address { get; set; }

        public virtual ICollection<Account> Accounts { get; set; } = new HashSet<Account>();
    }
}
