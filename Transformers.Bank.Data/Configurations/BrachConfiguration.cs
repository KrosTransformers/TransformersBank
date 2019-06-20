using System.Data.Entity.ModelConfiguration;
using Transformers.Bank.Entities;

namespace Transformers.Bank.Data.Configurations
{
    public class BrachConfiguration: EntityTypeConfiguration<Branch>
    {
        public BrachConfiguration()
        {
            this.ToTable(nameof(Branch));
            this.HasKey(x => x.Id);
            this.Property(x => x.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(x => x.CreatedAt).HasPrecision(3);
            this.Property(x => x.ChangedAt).HasPrecision(3);

            this.Property(x => x.BranchCode).IsRequired().HasMaxLength(10);
            this.Property(x => x.Name).IsRequired().HasMaxLength(50).IsUnicode();

            this.HasRequired<Address>(x => x.Address)
                .WithMany()
                .HasForeignKey(x => x.AddressId)
                .WillCascadeOnDelete(false);
        }
    }
}
