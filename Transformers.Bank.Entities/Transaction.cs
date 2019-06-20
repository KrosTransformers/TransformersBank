using System;

namespace Transformers.Bank.Entities
{
    public class Transaction: BaseEntity<long>
    {
        public long AccountId { get; set; }
        public virtual Account Account { get; set; }

        public string Iban { get; set; }
        public string Bic { get; set; }
        public decimal Amount { get; set; }
        public string PartnerName { get; set; }
        public string PayerReference { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public decimal OriginalAmount { get; set; }
        public string OriginalCurrency { get; set; }
        public decimal ExchangeRate { get; set; }
        public string SignedBy { get; set; }
    }
}
