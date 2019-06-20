using System.Data.Entity;
using Transformers.Bank.Data.Respositories;
using Transformers.Bank.Entities;

namespace Transformers.Bank.Data.Context
{
    public class DataWorker: DbContext, IDataWorker
    {
        private AddressRepository _addresses;
        private AccountRepository _accounts;
        private BranchRepository _branches;
        private CustomerRepository _customers;
        private TransactionRepository _transactions;

        public DataWorker(): base("name=TransformersBank")
        {

        }

        public AddressRepository Addresses => _addresses ?? (_addresses = new AddressRepository(Set<Address>(), this));

        public AccountRepository Accounts => _accounts ?? (_accounts = new AccountRepository(Set<Account>(), this));

        public BranchRepository Branches => _branches ?? (_branches = new BranchRepository(Set<Branch>(), this));

        public CustomerRepository Customers => _customers ?? (_customers = new CustomerRepository(Set<Customer>(), this));

        public TransactionRepository Transactions => _transactions ?? (_transactions = new TransactionRepository(Set<Transaction>(), this));



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(DataWorker).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
