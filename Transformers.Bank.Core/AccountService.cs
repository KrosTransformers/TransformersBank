using System.Collections.Generic;
using Transformers.Bank.Data.Context;
using Transformers.Bank.Entities;

namespace Transformers.Bank.Core
{
    public class AccountService
    {
        IDataWorker _dataWorker;

        public AccountService(IDataWorker dataWorker)
        {
            _dataWorker = dataWorker;
        }

        public List<Account> GetAll()
        {
            return _dataWorker.Accounts.GetAll();
        }
    }
}
