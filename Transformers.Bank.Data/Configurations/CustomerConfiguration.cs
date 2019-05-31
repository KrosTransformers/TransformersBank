using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transformers.Bank.Entities;

namespace Transformers.Bank.Data.Configurations
{
    public class CustomerConfiguration: EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            this.ToTable(nameof(Customer));
            this.HasKey(x => x.Id);
            this.Property(x => x.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(x => x.CreatedAt).HasPrecision(3);
            this.Property(x => x.ChangedAt).HasPrecision(3);

            this.Property(x => x.GivenName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            this.Property(x => x.FamilyName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            this.Property(x => x.PersonalId)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(x => x.EmailAddress).HasMaxLength(24);
            this.Property(x => x.PhoneNumber).HasMaxLength(15);

            this.HasRequired(x => x.ResidentialAddress)
                .WithMany()
                .HasForeignKey(x => x.ResidentialAddressId)
                .WillCascadeOnDelete(false);

            this.HasOptional(x => x.PostalAddress)
                .WithMany()
                .HasForeignKey(x => x.PostalAddressId)
                .WillCascadeOnDelete(false);
        }
    }
}
