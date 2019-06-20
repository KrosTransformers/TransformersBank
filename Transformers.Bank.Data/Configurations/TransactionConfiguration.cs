using System.Data.Entity.ModelConfiguration;
using Transformers.Bank.Entities;

namespace Transformers.Bank.Data.Configurations
{
    public class TransactionConfiguration: EntityTypeConfiguration<Transaction>
    {
        public TransactionConfiguration()
        {
            this.ToTable(nameof(Transaction));
            this.HasKey(x => x.Id);
            this.Property(x => x.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(x => x.CreatedAt).HasPrecision(3);
            this.Property(x => x.ChangedAt).HasPrecision(3);

            this.Property(x => x.Iban).IsRequired().HasMaxLength(34);
            this.Property(x => x.Bic).IsRequired().HasMaxLength(11);
            this.Property(x => x.Amount).HasPrecision(18, 2);
            this.Property(x => x.TransactionDate).HasPrecision(3);
            this.Property(x => x.OriginalAmount).HasPrecision(18, 2);
            this.Property(x => x.OriginalCurrency).HasMaxLength(3).IsRequired();
            this.Property(x => x.ExchangeRate).HasPrecision(12, 6);
        }
    }
}
