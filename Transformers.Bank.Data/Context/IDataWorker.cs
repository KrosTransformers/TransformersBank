using System;
using Transformers.Bank.Data.Respositories;

namespace Transformers.Bank.Data.Context
{
    public interface IDataWorker: IDisposable, IDbContext
    {
        AddressRepository Addresses { get; }
        AccountRepository Accounts { get; }
        BranchRepository Branches { get; }
        CustomerRepository Customers { get; }
        TransactionRepository Transactions { get; }
    }
}
