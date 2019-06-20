using System.Collections.Generic;

namespace Transformers.Bank.Entities
{
    public class Customer: BaseEntity<long>
    {
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string PersonalId { get; set; }
        public string AcademicPrefix { get; set; }
        public string AcademicSufix { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public long ResidentialAddressId { get; set; }
        public long? PostalAddressId { get; set; }

        public virtual Address ResidentialAddress { get; set; }
        public virtual Address PostalAddress { get; set; }

        public virtual ICollection<Account> OwnAccounts { get; set; } = new HashSet<Account>();
        public virtual ICollection<Account> DisponibleAccounts { get; set; } = new HashSet<Account>();
    }
}
