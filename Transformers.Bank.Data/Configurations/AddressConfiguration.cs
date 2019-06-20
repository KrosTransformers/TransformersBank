using System.Data.Entity.ModelConfiguration;
using Transformers.Bank.Entities;

namespace Transformers.Bank.Data.Configurations
{
    public class AddressConfiguration: EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            this.ToTable(nameof(Address));
            this.HasKey(x => x.Id);
            this.Property(x => x.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(x => x.CreatedAt).HasPrecision(3);
            this.Property(x => x.ChangedAt).HasPrecision(3);

            this.Property(x => x.Line1)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            this.Property(x => x.Line2)
                .HasMaxLength(50)
                .IsUnicode();

            this.Property(x => x.Town)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            this.Property(x => x.PostCode)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode();

            this.Property(x => x.Region)
                .HasMaxLength(50)
                .IsUnicode();

            this.Property(x => x.Country)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode();
        }
    }
}
