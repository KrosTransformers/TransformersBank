namespace Transformers.Bank.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 24),
                        Iban = c.String(nullable: false, maxLength: 34),
                        Bic = c.String(nullable: false, maxLength: 11),
                        Currency = c.String(nullable: false, maxLength: 3),
                        OverdraftLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Reservations = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Opened = c.DateTime(nullable: false, storeType: "date"),
                        Closed = c.DateTime(storeType: "date"),
                        BranchId = c.Long(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 3),
                        ChangedAt = c.DateTimeOffset(precision: 3),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .Index(t => t.Iban, unique: true)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Branch",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BranchCode = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 50),
                        AddressId = c.Long(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 3),
                        ChangedAt = c.DateTimeOffset(precision: 3),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.AddressId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Line1 = c.String(nullable: false, maxLength: 50),
                        Line2 = c.String(maxLength: 50),
                        Town = c.String(nullable: false, maxLength: 50),
                        PostCode = c.String(nullable: false, maxLength: 10),
                        Region = c.String(maxLength: 50),
                        Country = c.String(nullable: false, maxLength: 50),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 3),
                        ChangedAt = c.DateTimeOffset(precision: 3),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        GivenName = c.String(nullable: false, maxLength: 50),
                        FamilyName = c.String(nullable: false, maxLength: 50),
                        PersonalId = c.String(nullable: false, maxLength: 15),
                        AcademicPrefix = c.String(),
                        AcademicSufix = c.String(),
                        EmailAddress = c.String(maxLength: 24),
                        PhoneNumber = c.String(maxLength: 15),
                        ResidentialAddressId = c.Long(nullable: false),
                        PostalAddressId = c.Long(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 3),
                        ChangedAt = c.DateTimeOffset(precision: 3),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.PostalAddressId)
                .ForeignKey("dbo.Address", t => t.ResidentialAddressId)
                .Index(t => t.ResidentialAddressId)
                .Index(t => t.PostalAddressId);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AccountId = c.Long(nullable: false),
                        Iban = c.String(nullable: false, maxLength: 34),
                        Bic = c.String(nullable: false, maxLength: 11),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PartnerName = c.String(),
                        PayerReference = c.String(),
                        TransactionDate = c.DateTimeOffset(nullable: false, precision: 3),
                        OriginalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OriginalCurrency = c.String(nullable: false, maxLength: 3),
                        ExchangeRate = c.Decimal(nullable: false, precision: 12, scale: 6),
                        SignedBy = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 3),
                        ChangedAt = c.DateTimeOffset(precision: 3),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.AccountDisponent",
                c => new
                    {
                        AccountId = c.Long(nullable: false),
                        CustomerId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccountId, t.CustomerId })
                .ForeignKey("dbo.Account", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.AccountOwner",
                c => new
                    {
                        AccountId = c.Long(nullable: false),
                        CustomerId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccountId, t.CustomerId })
                .ForeignKey("dbo.Account", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "AccountId", "dbo.Account");
            DropForeignKey("dbo.AccountOwner", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.AccountOwner", "AccountId", "dbo.Account");
            DropForeignKey("dbo.AccountDisponent", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.AccountDisponent", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Customer", "ResidentialAddressId", "dbo.Address");
            DropForeignKey("dbo.Customer", "PostalAddressId", "dbo.Address");
            DropForeignKey("dbo.Account", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.Branch", "AddressId", "dbo.Address");
            DropIndex("dbo.AccountOwner", new[] { "CustomerId" });
            DropIndex("dbo.AccountOwner", new[] { "AccountId" });
            DropIndex("dbo.AccountDisponent", new[] { "CustomerId" });
            DropIndex("dbo.AccountDisponent", new[] { "AccountId" });
            DropIndex("dbo.Transaction", new[] { "AccountId" });
            DropIndex("dbo.Customer", new[] { "PostalAddressId" });
            DropIndex("dbo.Customer", new[] { "ResidentialAddressId" });
            DropIndex("dbo.Branch", new[] { "AddressId" });
            DropIndex("dbo.Account", new[] { "BranchId" });
            DropIndex("dbo.Account", new[] { "Iban" });
            DropTable("dbo.AccountOwner");
            DropTable("dbo.AccountDisponent");
            DropTable("dbo.Transaction");
            DropTable("dbo.Customer");
            DropTable("dbo.Address");
            DropTable("dbo.Branch");
            DropTable("dbo.Account");
        }
    }
}
